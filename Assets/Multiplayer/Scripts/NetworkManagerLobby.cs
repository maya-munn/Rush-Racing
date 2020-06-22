using Mirror;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles new server creations and client connections in multiplayer lobby
/// Inspired from DapperDino on YouTube
/// Author: Maya Ashizumi-Munn
/// </summary>
public class NetworkManagerLobby : NetworkManager
{
    //Setting minimum players for a race
    public int minPlayers = 2;
    private string raceTrackSceneName = "MultiplayerRaceTrack";

    //Reference to scene: lobby scene
    [Scene] public string MenuScene = string.Empty;

    //Reference to prefab for network room player
    [Header("Room")]
    public NetworkRoomPlayerLobby roomPlayerPrefab = null;
    [Header("Game")]
    public NetworkGamePlayerLobby gamePlayerPrefab = null;
    //Prefab that has the player spawn system on it
    public GameObject playerSpawnSystem = null;

    //Events (public to listen in to them from menu UI)
    public static event Action OnClientConnected;
    public static event Action OnClientDisconnected;
    public static event Action<NetworkConnection> OnServerReadied; //Only want to start game when everyone has connected

    //List of connected clients to display to all players who is in that lobby
    public List<NetworkRoomPlayerLobby> RoomPlayers { get; } = new List<NetworkRoomPlayerLobby>();
    public List<NetworkGamePlayerLobby> GamePlayers { get; } = new List<NetworkGamePlayerLobby>();

    //Register prefabs to be spawning on the network
    public override void OnStartServer() => spawnPrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs").ToList();

    public override void OnStartClient()
    {
        var spawnablePrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs");

        foreach (var prefab in spawnablePrefabs)
        {
            ClientScene.RegisterPrefab(prefab);
        }
    }

    //Called when client connects to a server
    public override void OnClientConnect(NetworkConnection conn)
    {
        //Do base logic, then raise the event
        base.OnClientConnect(conn);
        OnClientConnected?.Invoke();
    }

    //Called when client disconnects from a server
    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect(conn);
        OnClientDisconnected?.Invoke();
    }

    //Called when server has an inbound client connection
    public override void OnServerConnect(NetworkConnection conn)
    {
        //Disconnect client if max players on server
        if (numPlayers >= maxConnections)
        {
            conn.Disconnect();
            return;
        }

        //Disconnect client if server client is not in the menu scene
        //(Stops players joining if game is already in progress)
        if (SceneManager.GetActiveScene().path != MenuScene)
        {
            conn.Disconnect();
            return;
        }
    }

    //Called on server when client adds a new player
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        if (SceneManager.GetActiveScene().path == MenuScene)
        {
            //Set player as leader if no other leaders
            bool otherLeaders = false;
            foreach (var player in RoomPlayers)
            {
                if (player.IsLeader)
                {
                    otherLeaders = true;
                }
            }
            bool isLeader = !otherLeaders; //If there is other leader, set this isLeader to false

            //Spawn in players prefab and add this player to the server connection
            NetworkRoomPlayerLobby roomPlayerInstance = Instantiate(roomPlayerPrefab);

            //Set isLeader in the roomPlayerInstance
            roomPlayerInstance.IsLeader = isLeader;

            //Ties together the prefab object and the connection
            NetworkServer.AddPlayerForConnection(conn, roomPlayerInstance.gameObject);
        }
    }

    //Called when client disconnects from server
    public override void OnServerDisconnect(NetworkConnection conn)
    {
        //Removed disconnected player from our room list
        if (conn.identity != null)
        {
            var player = conn.identity.GetComponent<NetworkRoomPlayerLobby>();
            RoomPlayers.Remove(player);

            NotifyPlayersOfReadyState(); //Update everyones ready state
        }

        base.OnServerDisconnect(conn);
    }

    //Called for everyone when server is stopped
    public override void OnStopServer()
    {
        RoomPlayers.Clear();
        GamePlayers.Clear();
    }

    //Loop over all players to check their ready state
    public void NotifyPlayersOfReadyState()
    {
        foreach (var player in RoomPlayers)
        {
            player.HandleReadyToStart(IsReadyToStart());
        }
    }

    //Logic to see whether the game can be started
    private bool IsReadyToStart()
    {
        if (numPlayers < minPlayers) { return false; }  //Cant start if players less than min

        foreach (var Player in RoomPlayers)
        {
            if (!Player.IsReady) { return false; }      //Cant start if at least 1 player is not ready
        }

        return true;                                    //Have enough people and everyone is ready, then game is ready to play
    }

    //Checks if can start game
    public void StartGame()
    {
        if (SceneManager.GetActiveScene().path == MenuScene)
        {
            //If not ready to start, dont do anything
            if (!IsReadyToStart()) { return; }

            //Ready to start - put players in game scene
            ServerChangeScene("MultiplayerRaceTrack");
        }
    }

    //Handles when changing scenes
    public override void ServerChangeScene(string newSceneName)
    {
        //Going from multiplayer menu/lobby to game scene
        if (SceneManager.GetActiveScene().path == MenuScene && newSceneName.StartsWith(raceTrackSceneName))
        {
            //While transitioning scene, go over room players
            for (int i = RoomPlayers.Count - 1; i >= 0; i--)
            {
                //Get their connection
                var conn = RoomPlayers[i].connectionToClient;
                //Spawn in their game version prefab
                var gamePlayerInstance = Instantiate(gamePlayerPrefab);
                //Set display name (transfer from room display name)
                gamePlayerInstance.SetDisplayName(RoomPlayers[i].DisplayName);

                //Get rid of game player's room player instance
                NetworkServer.Destroy(conn.identity.gameObject);

                //Replace with new game player
                NetworkServer.ReplacePlayerForConnection(conn, gamePlayerInstance.gameObject);
            }
        }

        base.ServerChangeScene(newSceneName);
    }

    //Called as soon as the scene has loaded
    public override void OnServerSceneChanged(string sceneName)
    {
        if (sceneName.StartsWith("MultiplayerRace"))
        {
            //Spawn in the player spawn system (Server owned)
            GameObject playerSpawnSystemInstance = Instantiate(playerSpawnSystem);
            NetworkServer.Spawn(playerSpawnSystemInstance);
        }
    }

    //For checking if all players are ready
    public override void OnServerReady(NetworkConnection conn)
    {
        base.OnServerReady(conn);

        OnServerReadied?.Invoke(conn);
    }

}

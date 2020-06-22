using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Players spawned in by the server
/// Author: Maya Ashizumi-Munn
/// </summary>
public class PlayerSpawnSystem : NetworkBehaviour
{
    //Reference to player prefab
    public GameObject carPrefab = null;

    //Static - for every instance of this list share the same variables
    //Spawn positionings and rotations in the scene
    private static List<Transform> carSpawnPoints = new List<Transform>();

    //When a player spawns in, this number will be incremented - to know where to set next player
    private int nextIndex = 0;

    //Used to bind to a transparent object in the scene to set it as spawn point at run time
    public static void AddSpawnPoint(Transform transform)
    {
        //Adds whatever the set object's transform is to the list
        carSpawnPoints.Add(transform);

        //Make sure the order is correct
        carSpawnPoints = carSpawnPoints.OrderBy(x => x.GetSiblingIndex()).ToList();
    }
    public static void RemoveSpawnPoint(Transform transform) => carSpawnPoints.Remove(transform);


    //When someone is ready, subscribe to SpawnPlayer
    public override void OnStartServer() => NetworkManagerLobby.OnServerReadied += SpawnPlayer;

    //When player object destroyed, unsubscribe from the event
    [ServerCallback]
    private void OnDestroy() => NetworkManagerLobby.OnServerReadied -= SpawnPlayer;

    [Server]
    public void SpawnPlayer(NetworkConnection conn)
    {
        //Get next spawn point
        Transform spawnPoint = carSpawnPoints.ElementAtOrDefault(nextIndex);

        //Throw error if its null
        if (spawnPoint == null)
        {
            Debug.LogError($"Missing spawn point for player {nextIndex}");
            return;
        }

        //Spawn in the player, spawn at spawn points position and rotation
        GameObject playerInstance = Instantiate(carPrefab, carSpawnPoints[nextIndex].position, carSpawnPoints[nextIndex].rotation);

        //Spawn it on the other clients too
        NetworkServer.Spawn(playerInstance, conn);

        nextIndex++;
    }
}

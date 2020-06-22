using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class NetworkRoomPlayerLobby : NetworkBehaviour
{
    //Reference to Lobby UI panel
    public GameObject lobbyUI = null;

    //Reference to lobby UI components
    public Text[] playerNameTexts = new Text[4];    //Up to 4 players - show their names
    public Text[] playerReadyTexts = new Text[4];   //Shows ready status of each player
    public Button startGameButton = null;           //To start game (only shown to game leader)

    //Variables that can only be changed on the server
    //When changed on server, updated for all clients
    [SyncVar(hook = nameof(HandleReadyStatusChanged))]
    public bool IsReady = false;
    [SyncVar(hook = nameof(HandleDisplayNameChanged))]
    public string DisplayName = "Loading...";

    //Boolean to set if client is leader or not
    private bool isLeader;
    public bool IsLeader
    {
        //Checks whether isLeader is true or false, then sets Start button interactability to that boolean value
        set
        {
            isLeader = value;
            startGameButton.gameObject.SetActive(value);
        }

        get
        {
            return isLeader;
        }
    }

    //Reference to our lobby room/network manager
    private NetworkManagerLobby room;
    private NetworkManagerLobby Room
    {
        get
        {
            startGameButton.interactable = false; //Set false for everyone

            if (room != null) { return room; } //Get already instantiated lobby room

            //Instantiate room casted as NetworkManagerLobby
            return room = NetworkManager.singleton as NetworkManagerLobby;
        }
    }

    //Called on object that belongs to client
    public override void OnStartAuthority()
    {
        //Set display name as current username
        CmdSetDisplayName(PlayerPrefs.GetString("CurrentUsername"));

        lobbyUI.SetActive(true);
    }

    //Called on every NetworkBehaviour when its active on a client
    public override void OnStartClient()
    {
        //Add this instance to room players list
        Room.RoomPlayers.Add(this);

        //Update UI whenever something starts
        UpdateDisplay();
    }

    //Called when server caused this object to be destroyed
    public override void OnStopClient()
    {
        //Remove this instance to room players list
        Room.RoomPlayers.Remove(this);

        //Update UI whenever something starts
        UpdateDisplay();
    }

    public void QuitLobbySession()
    {
        this.OnStopClient();

        //If server-client was removed, then stop multiplayer session
        if (isLeader)
        {
            NetworkManager.Shutdown();
        }

        NetworkManager.Destroy(this);

        //Change to main menu
        SceneManager.LoadScene(0);
    }

    //Updates display for all clients if one client changes ready status or changes name
    public void HandleReadyStatusChanged(bool oldValue, bool newValue) => UpdateDisplay();
    public void HandleDisplayNameChanged(string oldValue, string newValue) => UpdateDisplay();

    private void UpdateDisplay()
    {
        //If its another client that updated their display
        if (!hasAuthority)
        {
            //Update our own display to match new display
            foreach (var player in Room.RoomPlayers)
            {
                if (player.hasAuthority)
                {
                    player.UpdateDisplay();
                    break;
                }
            }

            return;
        }

        //If our display has changed
        //Go over all player name texts and ready texts and reset them
        for (int i = 0; i < playerNameTexts.Length; i++)
        {
            playerNameTexts[i].text = "Waiting for player...";
            playerReadyTexts[i].text = string.Empty; 
        }
        //Go over number of players and set their name and ready texts accordingly
        for (int i = 0; i < Room.RoomPlayers.Count; i++)
        {
            playerNameTexts[i].text = Room.RoomPlayers[i].DisplayName;
            //Set text and colour based on if ready or not
            if (Room.RoomPlayers[i].IsReady)
            {
                playerReadyTexts[i].text = "Ready";
                playerReadyTexts[i].color = Color.green;
            }
            else
            {
                playerReadyTexts[i].text = "Not Ready";
                playerReadyTexts[i].color = Color.red;
            }
        }
    }

    //Toggles start button for leader if the game is ready to start
    public void HandleReadyToStart(bool readyToStart)
    {
        //If not leader, ignore this
        if (!isLeader) { return; }

        //Set interactability of the start button based on the ready to start check
        startGameButton.interactable = readyToStart;
    }

    [Command]
    private void CmdSetDisplayName(string displayName)
    {
        DisplayName = displayName;
    }

    [Command]
    public void CmdReadyUp()
    {
        //Toggle
        IsReady = !IsReady;

        //Whenever this changes, need to notify other players of our changed state
        Room.NotifyPlayersOfReadyState();
    }

    [Command]
    public void CmdStartGame()
    {
        //Checks if this player is NOT the leader
        if (Room.RoomPlayers[0].connectionToClient != connectionToClient) { return; }

        //If they are the leader, then start game
        Room.StartGame();
    }
}

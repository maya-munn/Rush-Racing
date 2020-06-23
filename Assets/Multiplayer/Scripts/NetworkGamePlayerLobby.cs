using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

/// <summary>
/// Author: Maya Ashizumi-Munn
/// </summary>
public class NetworkGamePlayerLobby : NetworkBehaviour
{

    //Variables that can only be changed on the server
    //When changed on server, updated for all clients
    [SyncVar]
    public string DisplayName = "Loading...";

    //Reference to our lobby room/network manager
    private NetworkManagerLobby room;
    private NetworkManagerLobby Room
    {
        get
        {
            if (room != null) { return room; } //Get already instantiated lobby room

            //Instantiate room casted as NetworkManagerLobby
            return room = NetworkManager.singleton as NetworkManagerLobby;
        }
    }

    //Called on every NetworkBehaviour when its active on a client
    public override void OnStartClient()
    {
        //When changing scene, game object will not be destroyed
        DontDestroyOnLoad(gameObject);

        //Add this instance to room players list
        Room.GamePlayers.Add(this);
    }

    //Called when server caused this object to be destroyed
    public override void OnStopClient()
    {
        //Remove this instance to room players list
        Room.GamePlayers.Remove(this);
    }

    [Server]
    public void SetDisplayName(string displayName)
    {
        this.DisplayName = displayName;
    }
}

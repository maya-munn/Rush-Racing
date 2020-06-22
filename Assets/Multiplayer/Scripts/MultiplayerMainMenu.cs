using UnityEngine;

/// <summary>
/// Handles multiplayer main menu UI
/// Author: Maya Ashizumi-Munn
/// </summary>
public class MultiplayerMainMenu : MonoBehaviour
{
    //Reference to Network Manager
    public NetworkManagerLobby networkManager = null;

    //Reference to the landing page panel to toggle 
    [Header("UI")]
    public GameObject landingPagePanel = null;

    //Called when Host Lobby button is pressed
    public void HostLobby()
    {
        //Tell network manager to start hosting from this client
        networkManager.StartHost();
    }
}

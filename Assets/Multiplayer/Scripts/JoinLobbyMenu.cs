using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages clients trying to join a server host through IP
/// 
/// Author: Maya Ashizumi-Munn
/// </summary>
public class JoinLobbyMenu : MonoBehaviour
{
    //Reference to NetworkManager
    public NetworkManagerLobby networkManager = null;

    //References to UI components
    public GameObject landingPagePanel = null;     //UI Canvas panel of landing page
    public InputField ipAddressInputField = null;  //Text box to enter IP address of host
    public Button joinLobbyButton = null;          //Button in lobby menu to join a host


    //Subscribe and unsubscribe from events when this gameobject is enabled/disabled
    private void OnEnable()
    {
        NetworkManagerLobby.OnClientConnected += HandleClientConnected;
        NetworkManagerLobby.OnClientDisconnected += HandleClientConnected;
    }
    private void OnDisable()
    {
        NetworkManagerLobby.OnClientConnected -= HandleClientConnected;
        NetworkManagerLobby.OnClientDisconnected -= HandleClientConnected;
    }

    //Called when Join Lobby button is pressed
    public void JoinLobby()
    {
        string ipAddress = ipAddressInputField.text; //Get the IP address user input in text field

        networkManager.networkAddress = ipAddress;  //Set the joining server IP as input provided
        networkManager.StartClient();

        joinLobbyButton.interactable = false;       //Ensure client can't click join twice
    }

    //Called when client has successfully connected to the server based on given IP
    private void HandleClientConnected()
    {
        joinLobbyButton.interactable = true; //Re-enable join button for future 

        gameObject.SetActive(false);
        landingPagePanel.SetActive(false);
    }

    //Called when client has unsuccessfully connected to server
    private void HandleClientDisconnected()
    {
        joinLobbyButton.interactable = true; //Make button available again
    }
}

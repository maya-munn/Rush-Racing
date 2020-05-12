using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script allows for personalisation of the main menu
/// Such as the username displayed up the top
/// Author: Maya Ashizumi-Munn
/// </summary>
public class WelcomeGreeting : MonoBehaviour
{
    public GameObject usernameText;
    // Start is called before the first frame update
    void Start()
    {
        string username = PlayerPrefs.GetString("SessionUsername");
        usernameText.GetComponent<TextMeshProUGUI>().text = "Hello, " + username + "!";
    }
}

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
    //Text UI object to modify
    public GameObject usernameText;
    //Reference to user database table
    private UserTable userTable;
    //String to store retrieved username
    string username;

    // Start is called before the first frame update
    void Start()
    {
        bool userExists = checkUserProfileExists();
        if (userExists)
        {
            //Get username 
            username = userTable.GetFirstUsername();
        }

        //Check if null
        if (username == null || username.Equals(""))
        {
            //Make invisible
            usernameText.SetActive(false);
        }
        else
        {
            //Make visible
            usernameText.SetActive(true);
            //Set the greeting text with username
            usernameText.GetComponent<TextMeshProUGUI>().text = "Hello, " + username + "!";
        }

    }

    private bool checkUserProfileExists()
    {
        //Create new instance of UserTable for DB access
        userTable = gameObject.AddComponent<UserTable>();
        bool existingUser = userTable.CheckForExistingUsers();

        //Return true if user exists
        return existingUser;
    }
}

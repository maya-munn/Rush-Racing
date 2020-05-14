using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This script first checks if there is a user profile existing in the DB
///   If no profile exists: stay on ProfileCreation scene
///   If profile exists: go to MainMenu scene 
/// Later versions will only check this when a user wants to play a new race
/// as there will be options to create and delete multiple profiles
/// 
/// If no profile exists, the user will need to enter a username and pin
/// Username: max 20 chars and pin max 4 integers (pin stored as hash)
/// 
/// Author: Maya Ashizumi-Munn
/// </summary>
public class CreateProfile : MonoBehaviour
{
    //UI Components
    public GameObject usernameTextBox;
    public GameObject pinNumTextBox;
    public GameObject feedbackLabel; //Feedback text label (if user input is invalid)
    public GameObject feedbackText;
    public GameObject createProfileButton;

    int mainMenuSceneIndex = 0; //Index of main menu scene

    //Connection to user table of DB
    UserTable userTable;

    //************************************//

    // Start is called before the first frame update
    void Start()
    {
        //Create a DB connection through UserTable script
        userTable = gameObject.AddComponent<UserTable>();
    }

    private void Update()
    {
        /* Make create profile button active only if:
         *   Username text box has 1 char
         *   Pin text box has 4 char
         */
        int usernameLength = usernameTextBox.GetComponent<Text>().text.Length;
        int pinLength = pinNumTextBox.GetComponent<Text>().text.Length;
        if (usernameLength > 1 && pinLength == 4) {
            createProfileButton.GetComponent<Button>().interactable = true;
        } else {
            createProfileButton.GetComponent<Button>().interactable = false;
        }
    }

    //************************************//

    public void createProfile()
    {
        //check if pin number is 4 integer numbers
        string pinString = pinNumTextBox.GetComponent<Text>().text;
        int pinNum = 0; //Only used for validation, real pin will not be stored
        bool goodPin = int.TryParse(pinString, out pinNum);

        if (goodPin)
        {
            //Create new DB entry and move onto main menu
            string username = usernameTextBox.GetComponent<Text>().text;
            int pin = createPinHash(pinString);

            //Check if theres an existing user
            bool existing = userTable.CheckForExistingUsers();
            if (existing)
            {
                //If theres a user already, override its userID
                //at userID 1 as that is default
                userTable.CreateOverrideUser(username, pin, 1);
            }
            else
            {
                //Create user normally
                userTable.CreateNewUser(username, pin);
            }

            //Query for ID based on username (both unique)
            int userID = userTable.GetIDFromUsername(username);
            PlayerPrefs.SetInt("SessionUserID", userID);

            SceneManager.LoadScene(mainMenuSceneIndex);
        }
        else
        {
            //Show feedback text
            feedbackLabel.SetActive(true);
            string feedback = "Pin is invalid! Please enter a 4-digit number.";
            feedbackText.GetComponent<Text>().text = feedback;

            //Clear input text boxes
            usernameTextBox.GetComponent<Text>().text = "";
            pinNumTextBox.GetComponent<Text>().text = "";
        }
    }

    /// <summary>
    /// Creates DJB2 hash of pin number
    /// </summary>
    /// <returns>DJB2 hash of user input pin</returns>
    public int createPinHash(string pinString)
    {
        int hash = 5381;    //Init value
        for (int i = 0; i < pinString.Length; i++)
        {
            char[] pinStringChars = pinString.ToCharArray();
            hash = pinStringChars[i] + ((hash << 5) - hash);
        }

        return hash;
    }
}

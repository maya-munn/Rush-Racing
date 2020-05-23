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
        userTable = new UserTable();
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

    /// <summary>
    /// Creates a new profile at a certain index
    /// </summary>
    /// <param name="indexAt">Index either 1, 2 or 3 of save slots</param>
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

            int indexAt = 0;
            //Get free user index
            if (PlayerPrefs.GetInt("UserOneID") == 0)
            {
                //ID 1 is free
                indexAt = 1;
                PlayerPrefs.SetInt("UserOneCoins", 100);
            }
            else
            {
                //ID 1 is not free
                if (PlayerPrefs.GetInt("UserTwoID") == 0)
                {
                    //ID 2 is free
                    indexAt = 2;
                    PlayerPrefs.SetInt("UserTwoCoins", 100);
                }
                else
                {
                    //ID 2 is not free
                    if (PlayerPrefs.GetInt("UserThreeID") == 0)
                    {
                        indexAt = 3;
                        PlayerPrefs.SetInt("UserThreeCoins", 100);
                    }
                }
            }

            //If all IDs were not free, prompt user to delete one
            if (indexAt == 0)
            {
                feedbackLabel.SetActive(true);
                string feedback = "No empty user profile slots! Please delete one before creating a new profile";
                feedbackText.GetComponent<Text>().text = feedback;
            }
            else
            {
                //Create user
                userTable.CreateNewUser(username, pin, indexAt);
                SceneManager.LoadScene(mainMenuSceneIndex);
            }
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

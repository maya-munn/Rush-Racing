using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the profile list settings menu - change username
/// Author: Maya Ashizumi-Munn
/// </summary>
public class ProfileListSettings : MonoBehaviour
{
    //UI components
    public GameObject changeUsernameButton;
    public GameObject newUsernameField;
    public GameObject confirmNewNameButton;

    //Send through the ID number of profile to change
    private int profileIDToChange;
    public void SetProfileID(int ID)
    {
        profileIDToChange = ID;
    }

    private void Start()
    {
        //Make text field and confirm button unavailable
        newUsernameField.SetActive(false);
        confirmNewNameButton.SetActive(false);
        confirmNewNameButton.GetComponent<Button>().interactable = false;
    }

    private void Update()
    {
        //Make confirm name button available if there is text in new username field]
        if (CheckForUsernameText() == true)
        {
            confirmNewNameButton.GetComponent<Button>().interactable = true;
        }
    }

    private bool CheckForUsernameText()
    {
        //Check if there is any text entered
        string usernameText = newUsernameField.GetComponentInChildren<Text>().text;
        if (usernameText.Length < 1 || usernameText.Contains("Enter new username..."))
        {
            //No text has been entered
            return false;
        }
        else
        {
            //Text has been entered
            return true;
        }
    }

    public void ChangeUsernameButtonClicked()
    {
        //Make the text field and confirm button available
        newUsernameField.SetActive(true);
        confirmNewNameButton.SetActive(true);
    }

    public void ConfirmNewUsernameButtonClicked()
    {
        //This button will only be active when there is text in the username field
        //So dont have to worry about checking input
        switch (profileIDToChange)
        {
            case 1:
                PlayerPrefs.SetString("UserOneName", newUsernameField.GetComponentInChildren<Text>().text);
                break;
            case 2:
                PlayerPrefs.SetString("UserTwoName", newUsernameField.GetComponentInChildren<Text>().text);
                break;
            case 3:
                PlayerPrefs.SetString("UserThreeName", newUsernameField.GetComponentInChildren<Text>().text);
                break;
        }

        //Call start method again to reset the panel
        this.Start();
    }
}

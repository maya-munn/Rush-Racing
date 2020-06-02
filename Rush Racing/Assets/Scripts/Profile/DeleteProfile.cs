using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteProfile : MonoBehaviour
{
    public GameObject playButtonOne;
    public GameObject playButtonTwo;
    public GameObject playButtonThree;

    public GameObject delButtonOne;
    public GameObject delButtonTwo;
    public GameObject delButtonThree;

    public void deleteProfile(int userID)
    {
        if (userID == PlayerPrefs.GetInt("CurrentUserID"))
        {
            //Set current username and userID to null
            PlayerPrefs.SetInt("CurrentUserID", 0);
            PlayerPrefs.SetString("CurrentUsername", null);

            
        }

        if (userID == 1)
        {
            PlayerPrefs.SetInt("UserOneID", 0);
            PlayerPrefs.SetString("UserOneName", null);
            PlayerPrefs.SetInt("UserOnePin", 0);

            playButtonOne.GetComponent<Button>().interactable = false;
            delButtonOne.GetComponent<Button>().interactable = false;
        }
        else if (userID == 2)
        {
            PlayerPrefs.SetInt("UserTwoID", 0);
            PlayerPrefs.SetString("UserTwoName", null);
            PlayerPrefs.SetInt("UserTwoPin", 0);

            playButtonTwo.GetComponent<Button>().interactable = false;
            delButtonTwo.GetComponent<Button>().interactable = false;
        }
        else
        {
            PlayerPrefs.SetInt("UserThreeID", 0);
            PlayerPrefs.SetString("UserThreeName", null);
            PlayerPrefs.SetInt("UserThreePin", 0);

            playButtonThree.GetComponent<Button>().interactable = false;
            delButtonThree.GetComponent<Button>().interactable = false;
        }
    }
}

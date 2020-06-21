using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Author: Maya Ashizumi-Munn
/// </summary>
/// 
public class ProfileListManager : MonoBehaviour
{
    public GameObject userOnePlayButton;
    public GameObject userTwoPlayButton;
    public GameObject userThreePlayButton;

    public GameObject userOneNameText;
    public GameObject userTwoNameText;
    public GameObject userThreeNameText;

    public GameObject delButtonOne;
    public GameObject delButtonTwo;
    public GameObject delButtonThree;

    public GameObject settingsButtonOne;
    public GameObject settingsButtonTwo;
    public GameObject settingsButtonThree;

    public GameObject userOneCoinsText;
    public GameObject userTwoCoinsText;
    public GameObject userThreeCoinsText;

    //Stores the status of which slots contain existing profiles
    bool[] existingProfiles;

    void Update()
    {
        userOneNameText.SetActive(false);
        userTwoNameText.SetActive(false);
        userThreeNameText.SetActive(false);
        userOneCoinsText.SetActive(false);
        userTwoCoinsText.SetActive(false);
        userThreeCoinsText.SetActive(false);

        //Get which user profiles at which index exist
        existingProfiles = gameObject.AddComponent<UserTable>().existingProfileIndices();

        if (existingProfiles[0] == true)
        {
            userOneNameText.SetActive(true);
            userOneCoinsText.SetActive(true);
            userOneNameText.GetComponent<Text>().text = PlayerPrefs.GetString("UserOneName");
            userOneCoinsText.GetComponent<Text>().text = "Coins: " + PlayerPrefs.GetInt("UserOneCoins");

            userOnePlayButton.GetComponent<Button>().interactable = true;
            delButtonOne.GetComponent<Button>().interactable = true;
            settingsButtonOne.GetComponent<Button>().interactable = true;
        }
        if (existingProfiles[1] == true)
        {
            userTwoNameText.SetActive(true);
            userTwoCoinsText.SetActive(true);
            userTwoNameText.GetComponent<Text>().text = PlayerPrefs.GetString("UserTwoName");
            userTwoCoinsText.GetComponent<Text>().text = "Coins: " + PlayerPrefs.GetInt("UserTwoCoins");

            userTwoPlayButton.GetComponent<Button>().interactable = true;
            delButtonTwo.GetComponent<Button>().interactable = true;
            settingsButtonTwo.GetComponent<Button>().interactable = true;
        }
        if (existingProfiles[2] == true)
        {
            userThreeNameText.SetActive(true);
            userThreeCoinsText.SetActive(true);
            userThreeNameText.GetComponent<Text>().text = PlayerPrefs.GetString("UserThreeName");
            userThreeCoinsText.GetComponent<Text>().text = "Coins: " + PlayerPrefs.GetInt("UserThreeCoins");

            userThreePlayButton.GetComponent<Button>().interactable = true;
            delButtonThree.GetComponent<Button>().interactable = true;
            settingsButtonThree.GetComponent<Button>().interactable = true;
        }
    }
}

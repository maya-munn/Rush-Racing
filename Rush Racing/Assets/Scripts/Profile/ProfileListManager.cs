using UnityEngine;

public class ProfileListManager : MonoBehaviour
{
    public GameObject userOnePlayButton;
    public GameObject userTwoPlayButton;
    public GameObject userThreePlayButton;

    //Stores the status of which slots contain existing profiles
    bool[] existingProfiles;

    void Start()
    {
        //Get which user profiles at which index exist
        existingProfiles = gameObject.AddComponent<UserTable>().existingProfileIndices();
    }

    //Methods for button onClicks
    public void switchToUserOne()
    {
        //If set to true (profile exists at first slot)
        if (existingProfiles[0])
        {
            //Then load in the profile at this slot and return into main menu

        }
        else
        {
            //Else redirect to create profile scene
        }
        PlayerPrefs.SetInt("CurrentUserID", 1);
    }
    public void switchToUserTwo()
    {
        PlayerPrefs.SetInt("CurrentUserID", 2);
    }
    public void switchToUserThree()
    {
        PlayerPrefs.SetInt("CurrentUserID", 3);
    }
}

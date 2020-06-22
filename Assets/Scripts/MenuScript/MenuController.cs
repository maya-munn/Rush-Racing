using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Contains methods to traverse through scenes and 
/// change scenes when buttons are pressed
/// 
/// Collaborators: Bernie and Henry
/// </summary>
public class MenuController : MonoBehaviour
{
    public enum SceneIndex
    {
        PreLoader = 0,
        MainMenu = 1,
        FreePlay = 2,
        Tournament = 3,
        Garage = 4,
        ProfileCreation = 5,
        ProfileList = 6,
        Options = 7,
<<<<<<< Updated upstream
        Track1 = 8,
        Track2 = 9,
=======
        MultiplayerMenu = 8
>>>>>>> Stashed changes
    }

    //**************************//
    public GameObject MapSelected = default;
    public void MainMenu()
    {
        SceneManager.LoadScene((int)SceneIndex.MainMenu);
    }

    public void FreePlayMode()
    {
        SceneManager.LoadScene((int)SceneIndex.FreePlay);

    }

    public void ProfileList()
    {
        SceneManager.LoadScene((int)SceneIndex.ProfileList);
    }


    public void TournamentMode()
    {
        SceneManager.LoadScene((int)SceneIndex.Tournament);
    }
    public void TournamentStart()
    {
        PlayerPrefs.SetInt("Tournament", 1);
        SceneManager.LoadScene((int)MenuController.SceneIndex.Track1);
    }

    public void GarageScene()
    {
        SceneManager.LoadScene((int)SceneIndex.Garage);
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void BackToMainMenu()
    {
        PlayerPrefs.SetInt("Tournament", 0);
        this.MainMenu();
    }

    public void StartButton()
    {
        if (MapSelected == null) return;
        int map = MapSelected.GetComponent<HorizontalSelector>().index;

        if (map == 0)
            SceneManager.LoadScene((int)SceneIndex.Track1);

        else if (map == 1)
            SceneManager.LoadScene((int)SceneIndex.Track2);
    }



    public void CreateProfileMenu()
    {
        SceneManager.LoadScene((int)SceneIndex.ProfileCreation);
    }

    /// <summary>
    /// Allows access to options menu from any scene
    /// 
    /// Author: Maya Ashizumi-Munn
    /// </summary>
    public void OptionsMenu()
    {
        SceneManager.LoadScene((int)SceneIndex.Options);
    }

    public void MultiplayerMenu()
    {
        SceneManager.LoadScene((int)SceneIndex.MultiplayerMenu);
    }
}

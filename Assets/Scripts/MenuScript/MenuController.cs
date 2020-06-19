using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
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
    private enum SceneIndex
    {
        PreLoader = 0,
        MainMenu = 1,
        FreePlay = 2,
        Tournament = 3,
        Garage = 4,
        RaceScene = 5,
        ProfileCreation = 6,
        ProfileList = 7,
        Options = 8
    }

    //**************************//

    public void MainMenu()
    {
        SceneManager.LoadScene((int)SceneIndex.MainMenu);
    }

    public void FreePlayMode()
    {
        SceneManager.LoadScene((int)SceneIndex.FreePlay);
    }

    public void ProfileList(){
        SceneManager.LoadScene((int)SceneIndex.ProfileList);
    }
    
    public void TournamentMode()
    {
        SceneManager.LoadScene((int)SceneIndex.Tournament);
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
        this.MainMenu();
    }
    public void StartButton()
    {
        SceneManager.LoadScene((int)SceneIndex.RaceScene);
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
}

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
        MainMenu = 0,
        FreePlay = 1,
        Tournament = 2,
        Garage = 3,
        RaceScene = 4,
        ProfileCreation = 5
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
        //Load main menu scene
        this.MainMenu();
        Scene mainScene = SceneManager.GetActiveScene();

        //Find canvas object
        GameObject canvasObject = GameObject.Find("Canvas");

        //Find canvas menu objects
        GameObject mainMenu = canvasObject.transform.Find("MainMenu").gameObject;
        GameObject playMenu = canvasObject.transform.Find("PlayMenu").gameObject;
        GameObject optionsMenu = canvasObject.transform.Find("OptionMenu").gameObject;

        //Set only options menu visibility to true
        mainMenu.SetActive(false);
        playMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
}

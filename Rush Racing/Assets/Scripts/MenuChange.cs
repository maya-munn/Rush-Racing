using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
    This script allows buttons to be clicked to navigate around menus 
    (Not including gameplay scenes for now)

    Author: Bernadette Cruz
*/
public class MenuChange : MonoBehaviour
{   //add default screen to start in later

    public void CreateProfileMenu()
    {
        SceneManager.LoadScene((int)Scene.ProfileCreation);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene((int)Scene.MainMenu);
    }

    public void Garage()
    {   
        SceneManager.LoadScene((int)Scene.Garage);
    }

    public void PlayMenu()
    {
        SceneManager.LoadScene((int)Scene.PlayMenu);
    }

    public void FreePlayMenu()
    {
        SceneManager.LoadScene((int)Scene.FreePlay);
    }

    public void Tournament()
    {
        SceneManager.LoadScene((int)Scene.Tournament);
    }

    private enum Scene
    {
        ProfileCreation = 0,
        MainMenu = 1,
        Garage = 2,
        PlayMenu = 3,
        FreePlay = 4,
        Tournament = 5
    }
}

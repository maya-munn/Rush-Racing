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
        MainMenu = 0,
        FreePlay = 1,
        Tournament = 2,
        Garage = 3,
        RaceScene = 4,
        ProfileCreation = 5
    }
}

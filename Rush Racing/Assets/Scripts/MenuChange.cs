using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
    This script allows buttons to be clicked to navigate around menus 
    (Not including gameplay scenes for now)
*/
public class MenuChange : MonoBehaviour
{   //add default screen to start in later

    public void Garage()
    {   
        SceneManager.LoadScene(1);
    }

    public void PlayMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void FreePlayMenu()
    {
        SceneManager.LoadScene(3);
    }

        public void Tournament()
    {
        SceneManager.LoadScene(4);
    }

    public void MainMenu()
    {   
        SceneManager.LoadScene(0);
    }
}

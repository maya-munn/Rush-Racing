    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenuController : MonoBehaviour
{
    public GameObject Pausedmenu, PauseButton, SettingsMenu;
    public GameObject InGameUICanvas; 
   

    public  void Pause()
       {
        Pausedmenu.SetActive(true);
        PauseButton.SetActive(false);
        SettingsMenu.SetActive(false);
        InGameUICanvas.SetActive(false);
        Time.timeScale = 0;
      }

    public void Resume()
    {
        Pausedmenu.SetActive(false);
        PauseButton.SetActive(true);
        SettingsMenu.SetActive(false);
        InGameUICanvas.SetActive(true);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene((int)Menuscene.MainMenu);
    }

    private enum Menuscene
    {
        RaceScene1 = 1, 
        MainMenu = 0,
        Restart = 4

    }

    public void Restart()
    {
        Pausedmenu.SetActive(false);
        SettingsMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene((int)Menuscene.MainMenu);
    }

    public void Settings()
    {
        Pausedmenu.SetActive(false);
        PauseButton.SetActive(false);
        SettingsMenu.SetActive(true);
        InGameUICanvas.SetActive(false);
        Time.timeScale = 0;
    }

    public void BackButton()
    {
        Pausedmenu.SetActive(true);
        PauseButton.SetActive(false);
        SettingsMenu.SetActive(false);
        Time.timeScale = 0;
    }


}

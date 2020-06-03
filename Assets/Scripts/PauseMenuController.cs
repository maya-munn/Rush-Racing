using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject Pausedmenu, PauseButton, SettingsMenu;
   

    public  void Pause()
       {
        Pausedmenu.SetActive(true);
        PauseButton.SetActive(false);
        SettingsMenu.SetActive(false);
        Time.timeScale = 0;
      }

    public void Resume()
    {
        Pausedmenu.SetActive(false);
        PauseButton.SetActive(true);
        SettingsMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        SceneManager.LoadScene((int)Menuscene.MainMenu);
        SceneManager.LoadScene(0);
    }

    private enum Menuscene
    {
        MainMenu = 0,
        Restart = 4

    }

    public void Restart()
    {
        Pausedmenu.SetActive(false);
        SettingsMenu.SetActive(false);
        SceneManager.LoadScene((int)Menuscene.Restart);
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

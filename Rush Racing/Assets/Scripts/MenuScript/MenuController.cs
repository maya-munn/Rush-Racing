using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void FreePlayMode()
    {
        SceneManager.LoadScene(1);
    }

    public void TournamentMode()
    {
        SceneManager.LoadScene(2);
    }


    public void GarageScene()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

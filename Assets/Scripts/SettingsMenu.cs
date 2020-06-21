using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public void SetQuality(int graphicsIndex)
    {

        QualitySettings.SetQualityLevel(graphicsIndex);
    }

    private enum Menuscene
    {
        MainMenu = 0,
    }

    public void backButton()
    {
        SceneManager.LoadScene((int)Menuscene.MainMenu);
    }

}

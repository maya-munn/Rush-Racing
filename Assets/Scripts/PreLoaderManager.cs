using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLoaderManager : MonoBehaviour
{
    private CanvasGroup fadeEffect;
    private float loadTime;
    private float minimumLogoDisplayTime = 3.0f;
    private void Start()
    {
        fadeEffect = FindObjectOfType<CanvasGroup>();
        fadeEffect.alpha = 1;
        //Preload the Game if we have

        // Get a time stamp for completion time
        // If loadtime is super, give a small buffer time for the logo
        if (Time.time < minimumLogoDisplayTime) loadTime = minimumLogoDisplayTime;
        else loadTime = Time.time;
    }
    private void Update()
    {
        //Fade in effect
        if (Time.time < minimumLogoDisplayTime) fadeEffect.alpha = 1 - Time.time;

        //Fade out effect
        if (Time.time > minimumLogoDisplayTime && loadTime != 0)
        {
            fadeEffect.alpha = Time.time - minimumLogoDisplayTime;
            if (fadeEffect.alpha >= 1)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

}

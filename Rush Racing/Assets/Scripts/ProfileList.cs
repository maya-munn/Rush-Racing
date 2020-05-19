using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProfileList : MonoBehaviour
{

    
    public void CreateProfile(){
        SceneManager.LoadScene("ProfileCreation");
    }

    public void BackButton(){
        SceneManager.LoadScene((int)Scene.MainMenu);
    }


    private enum Scene
    {
        MainMenu = 0,
        FreePlay = 1,
        Tournament = 2,
        Garage = 3,
        RaceScene = 4,
        ProfileCreation = 5,
        ProfileList = 6
    }
}

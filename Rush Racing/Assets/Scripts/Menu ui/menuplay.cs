using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menuplay : MonoBehaviour
{
   
    public void sceneLoader(int SceneMenu)
    {
        SceneManager.LoadScene(SceneMenu);
    }
}

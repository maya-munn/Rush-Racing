using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Checks for an existing profile to save race data into 
/// Author: Maya Ashizumi-Munn
/// </summary>
public class CheckForProfile : MonoBehaviour
{
    //Change this if main menu index has changed
    private int createProfileSceneIndex = 5;

    /// <summary>
    /// Called from Play button, takes user to create profile scene if there is no user profile
    /// in the database
    /// </summary>
    public void CheckExistingProfile()
    {
        //Create new instance of UserTable for DB access
        UserTable userTable = gameObject.AddComponent<UserTable>();
        bool existingUser = userTable.CheckForExistingUsers();

        //Change scene to createprofile if there is no existing user profile
        if (existingUser != true)
        {
            SceneManager.LoadScene(createProfileSceneIndex);
        }
    }
}

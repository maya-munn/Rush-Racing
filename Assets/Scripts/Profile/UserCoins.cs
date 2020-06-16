using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Author: Bernadette Cruz
/// Allows the current user's currency to be outputted to any menu (on the top left)
/// /// </summary>

public class UserCoins : MonoBehaviour
{
    public GameObject Coins;
    void Update()
    {
        //Checks if a current profile is selected
        bool userExists = checkUserProfileExists();
        if (userExists)
        {
            //Gets value of current profile coins set in script "SwitchProfile"
            Coins.GetComponent<TextMeshProUGUI>().text = "$" + gameObject.AddComponent<CurrencyTable>().GetUserCurrency();
        }
        else
        {
            Coins.SetActive(false);
        }
    }


    //used this method from "WelcomeGreeting" script to check if a user profile exists
    private bool checkUserProfileExists()
    {
        //Create new instance of UserTable for DB access
        bool existingUser = gameObject.AddComponent<UserTable>().CheckForExistingUsers();

        //Return true if user exists
        return existingUser;
    }
}

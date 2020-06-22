using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// (Update) Bernadette Cruz: Created Playerprefs "CurrentCoins" to output current profile's coins in menus
/// </summary>
public class SwitchProfile : MonoBehaviour
{
    public void switchToUserOne()
    {
        PlayerPrefs.SetInt("CurrentUserID", 1);
        PlayerPrefs.SetString("CurrentUsername", PlayerPrefs.GetString("UserOneName"));
        PlayerPrefs.SetInt("CurrentCoins", PlayerPrefs.GetInt("UserOneCoins"));
        gameObject.AddComponent<MenuController>().MainMenu();
    }
    public void switchToUserTwo()
    {
        PlayerPrefs.SetInt("CurrentUserID", 2);
        PlayerPrefs.SetString("CurrentUsername", PlayerPrefs.GetString("UserTwoName"));
        PlayerPrefs.SetInt("CurrentCoins", PlayerPrefs.GetInt("UserTwoCoins"));
        gameObject.AddComponent<MenuController>().MainMenu();
    }
    public void switchToUserThree()
    {
        PlayerPrefs.SetInt("CurrentUserID", 3);
        PlayerPrefs.SetString("CurrentUsername", PlayerPrefs.GetString("UserThreeName"));
        PlayerPrefs.SetInt("CurrentCoins", PlayerPrefs.GetInt("UserThreeCoins"));
        gameObject.AddComponent<MenuController>().MainMenu();
    }
}

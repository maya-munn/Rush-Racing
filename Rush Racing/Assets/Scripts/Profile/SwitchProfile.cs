using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchProfile : MonoBehaviour
{
    public void switchToUserOne()
    {
        PlayerPrefs.SetInt("CurrentUserID", 1);
        PlayerPrefs.SetString("CurrentUsername", PlayerPrefs.GetString("UserOneName"));
        gameObject.AddComponent<MenuController>().MainMenu();
    }
    public void switchToUserTwo()
    {
        PlayerPrefs.SetInt("CurrentUserID", 2);
        PlayerPrefs.SetString("CurrentUsername", PlayerPrefs.GetString("UserTwoName"));
        gameObject.AddComponent<MenuController>().MainMenu();
    }
    public void switchToUserThree()
    {
        PlayerPrefs.SetInt("CurrentUserID", 3);
        PlayerPrefs.SetString("CurrentUsername", PlayerPrefs.GetString("UserThreeName"));
        gameObject.AddComponent<MenuController>().MainMenu();
    }
}

using UnityEngine;

/// <summary>
/// Changes current user values to the one selected
/// Author: Maya Ashizumi-Munn
/// </summary>
public class SwitchProfile : MonoBehaviour
{
    public void switchToUserOne()
    {
        PlayerPrefs.SetInt("CurrentUserID", 1);
        PlayerPrefs.SetString("CurrentUsername", PlayerPrefs.GetString("UserOneName"));
        PlayerPrefs.SetInt("CurrentUserCoins", PlayerPrefs.GetInt("UserOneCoins"));
        gameObject.AddComponent<MenuController>().MainMenu();
    }
    public void switchToUserTwo()
    {
        PlayerPrefs.SetInt("CurrentUserID", 2);
        PlayerPrefs.SetString("CurrentUsername", PlayerPrefs.GetString("UserTwoName"));
        PlayerPrefs.SetInt("CurrentUserCoins", PlayerPrefs.GetInt("UserTwoCoins"));
        gameObject.AddComponent<MenuController>().MainMenu();
    }
    public void switchToUserThree()
    {
        PlayerPrefs.SetInt("CurrentUserID", 3);
        PlayerPrefs.SetString("CurrentUsername", PlayerPrefs.GetString("UserThreeName"));
        PlayerPrefs.SetInt("CurrentUserCoins", PlayerPrefs.GetInt("UserThreeCoins"));
        gameObject.AddComponent<MenuController>().MainMenu();
    }
}

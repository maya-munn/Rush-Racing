using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Author: Bernadette Cruz
/// Checks at the end of the race if mode is freeplay or tournament, if tournament mode, allows the player to go to the next race
/// </summary>
public class TournamentMode : MonoBehaviour
{
    private int tracks = 2;
    public GameObject RaceOptionText;
 
    void Start()
    {
        //if game mode is not tournament, simply restarts the race.
        if (PlayerPrefs.GetInt("Tournament") == 0)
        {
            RaceOptionText.GetComponent<Text>().text = "RESTART";
        }

        //if game mode is tournament and is currently in track 1.
        if (PlayerPrefs.GetInt("Tournament") == 1)
        {
            RaceOptionText.GetComponent<Text>().text = "NEXT RACE";
        }

        //if tournament mode is finished
        if (PlayerPrefs.GetInt("Tournament") == tracks)
        {
            RaceOptionText.SetActive(false);
        }
           // CheckTournament();
    }

    public void CheckTournament()
    {
        if (PlayerPrefs.GetInt("Tournament") == 1)
        {
            PlayerPrefs.SetInt("Tournament", PlayerPrefs.GetInt("Tournament") + 1);
            SceneManager.LoadScene((int)MenuController.SceneIndex.Track2);
        }

        else RestartRace();

    }

    private void RestartRace()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}

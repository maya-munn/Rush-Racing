using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Author: Immanuel Siregar
//This code was inspired by the code from Jimmy Vegas' Unity Racing Game tutorial. Assets 'GetReady' and 'GoAudio' were used from his website, as placeholders right now. As development continues, we would likely use or create our own assets.
//Update (Bernadette Cruz): added disable car controls during countdown, which is enabled after countdown finishes.
//Update (Maya Ashizumi-Mun): added royalty-free music during the race
//Update (Bernadette Cruz): added component that modifies number of total laps which the player has chosen.
public class Countdown : MonoBehaviour
{
    //Connects to the GameObjects and audio files in the coundown animation
    public GameObject CountDown;
    public AudioSource GetReady;
    public AudioSource GoAudio;
    public AudioSource MusicTrack;
    public GameObject LapTimer;
    public GameObject TotalLapTimer;
    public GameObject TotalLaps;
    public GameObject AILapTimer;
    public GameObject CarController;

    //On start, calls the animation
    void Start()
    {
        TotalLaps.GetComponent<Text>().text = "/ " + PlayerPrefs.GetInt("Laps");
        StartCoroutine(CountStart());
    }

    //Basically the structure of what occurs during the animation before the start.
    //Accesses the countdown UI object to display the countdown numbers.
    IEnumerator CountStart()
    {
        yield return new WaitForSeconds(0.5f);
        CountDown.GetComponent<Text>().text = "3";
        GetReady.Play();
        CountDown.SetActive(true);

        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        CountDown.GetComponent<Text>().text = "2";
        GetReady.Play();
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        CountDown.GetComponent<Text>().text = "1";
        GetReady.Play();
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        CountDown.GetComponent<Text>().text = "GO!";
        GoAudio.Play();
        LapTimer.SetActive(true);
        TotalLapTimer.SetActive(true);
        AILapTimer.SetActive(true);
        CarController.SetActive(true);

        //Start music half of a second after race starts
        yield return new WaitForSeconds(0.5f);
        MusicTrack.Play();
    }

}

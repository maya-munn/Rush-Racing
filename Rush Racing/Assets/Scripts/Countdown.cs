using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Author: Immanuel Siregar
//This code was heavily inspired by the code from Jimmy Vegas' Unity Racing Game tutorial. Assets 'GetReady' and 'GoAudio' were used from his website, as placeholders right now. As development continues, we would likely use or create our own assets.
//Update (Bernadette Cruz): added disable car controls during countdown, which is enabled after countdown finishes.
public class Countdown : MonoBehaviour
{
    //Connects to the GameObjects and audio files in the coundown animation
    public GameObject CountDown;
    public AudioSource GetReady;
    public AudioSource GoAudio;
    public GameObject LapTimer;
    public GameObject CarController;

    //On start, calls the animation
    void Start()
    {        
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
        CarController.SetActive(true);
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Author: Immanuel Siregar
//Inspired from Jimmy Vegas' Unity Tutorial
//(Update) Bernadette Cruz: Modified laps done to number of laps chosen by player

public class LapComplete : MonoBehaviour
{
    //The Finish Line trigger and the Halfway Checkpoint trigger
    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    //The GameObjects that will hold the digits representing the time (Minutes, Seconds, Milliseconds).
    public GameObject MinuteDisplay;
    public GameObject SecondDisplay;
    public GameObject MilliDisplay;

    //Will hold the display objects
    public GameObject LapTimeBox;

    //Lap Counter will hold the LapsDone integer, which will increment once player has completed a lap.
    public GameObject LapCounter;
    public int LapsDone;

    public GameObject RaceFinish;

    //Will set the status of RaceFinish to true, which will unlock the last checkpoint which will throw up the scoreboard.
    public void Update(){
<<<<<<< Updated upstream:Assets/Scripts/RaceLapManager/LapComplete.cs
    if (LapsDone == PlayerPrefs.GetInt("Laps")){
=======
    if (LapsDone == 0){
>>>>>>> Stashed changes:Assets/Scripts/LapComplete.cs
        RaceFinish.SetActive(true);
    }
    }

    public void OnTriggerEnter()
    {
        //Increments the player's laps done by one everytime they enter the trigger
        LapsDone += 1;

        //For the Lap Timer, it will reset the Millisecond, Second, and Minute displays back to zero, and starts the new lap from zero. The nested if statement will basically handle the string content in the Lap 
        if (LapTimeManager.SecondCount <= 9)
            {
                SecondDisplay.GetComponent<Text>().text = "0" + LapTimeManager.SecondCount + ".";
            }
            else
            {
                SecondDisplay.GetComponent<Text>().text = "" + LapTimeManager.SecondCount + ".";
            }

            if (LapTimeManager.MinuteCount <= 9)
            {
                MinuteDisplay.GetComponent<Text>().text = "0" + LapTimeManager.MinuteCount + ":";
            }
            else
            {
                MinuteDisplay.GetComponent<Text>().text = "" + LapTimeManager.MinuteCount + ":";
            }

            MilliDisplay.GetComponent<Text>().text = "" + LapTimeManager.MilliCount;
        

        //Will reset the lap time to 0 everytime the player completes a lap.
        LapTimeManager.MinuteCount = 0;
        LapTimeManager.SecondCount = 0;
        LapTimeManager.MilliCount = 0;

        //The LapsDone (and therefore the LapCounter) will update whenever a player completes a lap.
        LapCounter.GetComponent<Text>().text = "" + LapsDone;

        //Initially, the LapCompleteTrig (a trigger in the form of an invisible game shape entity) will be set to false, while the HalfLapTrig (a similar checkpoint in the middle of the track) will be active. This means the player has to cross the halfway checkpoint before entering the Lap Complete trigger.
        HalfLapTrig.SetActive(true);
        LapCompleteTrig.SetActive(false);
    }
}

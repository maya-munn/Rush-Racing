using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Author: Immanuel Siregar
//Update (Bernadette Cruz) Added Gameobjects 'LapBox' and 'TotalTimeBox' which represents LapTimeManager and TotalLap time that deactivates
//                         at the end of the race to freeze the lap times on the screen.

public class RaceFinish : MonoBehaviour
{
    public GameObject LapBox;
    public GameObject TotalTimeBox;
    public GameObject StatsPanel;
    public GameObject TotalLapMins;
    public GameObject TotalLapSecs;
    public GameObject TotalLapMilli;
    public GameObject MinStats;
    public GameObject SecStats;
    public GameObject MilliStats;
    public GameObject CashEarned;
    public GameObject LapCompleteCounter;
    //public GameObject AIRaceFinish;


    //Will put up the scoreboard when the Racefinish trigger is activated.
    void OnTriggerEnter(Collider PlayerCar)
    {
        if (PlayerCar.tag == "Player")
        {
            LapCompleteCounter.SetActive(false);
            LapBox.SetActive(false);
            TotalTimeBox.SetActive(false);
            StatsPanel.SetActive(true);
            GameObject.Find("AIRaceFinish").SetActive(true);



            //Update(Bernie) Takes the total lap time to be outputted next to the player's name in the stats panel
            MinStats.GetComponent<Text>().text = TotalLapMins.GetComponent<Text>().text;
            SecStats.GetComponent<Text>().text = TotalLapSecs.GetComponent<Text>().text;
            MilliStats.GetComponent<Text>().text = TotalLapMilli.GetComponent<Text>().text;

            //Gets username and outputs to stats panel
            GameObject.Find("PlayerName").GetComponent<Text>().text = PlayerPrefs.GetString("CurrentUsername");

            gameObject.AddComponent<CurrencyTable>().AddToUserCurrency(500);
            PlayerPrefs.SetInt("CurrentCoins", gameObject.GetComponent<CurrencyTable>().GetUserCurrency());

            //update(Bernie) Outputs cash earned to Stats panel ---> hardcoded to $500 for now
            CashEarned.GetComponent<Text>().text = "+$500";

        }

        /*
        void OnTriggerEnter (Collider AIcar){

            if(AIcar.tag == "AI_Car"){
                AITimeBox.SetActive(false);

                AIMinStats.GetComponent<Text>().text = AILapMins.GetComponent<Text>().text;
                AISecStats.GetComponent<Text>().text = AILapSecs.GetComponent<Text>().text;
                AIMilliStats.GetComponent<Text>().text = AILapMilli.GetComponent<Text>().text;
            }
        }
        */
        }
    }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIRaceFinish : MonoBehaviour
{
    public GameObject AITimeBox;
    //public GameObject AILapBox;
    public GameObject AIMinStats;
    public GameObject AISecStats;
    public GameObject AIMilliStats;
    public GameObject AITotalLapMins;
    public GameObject AITotalLapSecs;
    public GameObject AITotalLapMilli;
    public GameObject AIStatsBox;
    public GameObject AIStatusText;
    void OnTriggerEnter(Collider AICar){
        if(AICar.tag == "AI_Car"){
            //AILapBox.SetActive(false);
            AITimeBox.SetActive(false);

            //deactivate "Still in Race" text in stats panel when AI enters the finish line
            AIStatusText.SetActive(false);

            //Show AI's total lap time in stats panel
            AIStatsBox.SetActive(true);
            AITotalLapMins.GetComponent<Text>().text = AIMinStats.GetComponent<Text>().text;
            AITotalLapSecs.GetComponent<Text>().text = AISecStats.GetComponent<Text>().text;
            AITotalLapMilli.GetComponent<Text>().text = AIMilliStats.GetComponent<Text>().text;
        }
    }

}

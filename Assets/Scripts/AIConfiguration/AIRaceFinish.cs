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

    void OnTriggerEnter(Collider AICar){
        if(AICar.tag == "AI_Car"){
            //AILapBox.SetActive(false);
            AITimeBox.SetActive(false);
            
            AIMinStats.GetComponent<Text>().text = AITotalLapMins.GetComponent<Text>().text;
            AISecStats.GetComponent<Text>().text = AITotalLapSecs.GetComponent<Text>().text;
            AIMilliStats.GetComponent<Text>().text = AITotalLapMilli.GetComponent<Text>().text;
        }
    }

}

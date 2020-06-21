using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AILapCount : MonoBehaviour
{
    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    public GameObject AILapCounter;
    public int AILapsDone;

    public GameObject AIRaceFinish;
    
    // Update is called once per frame
    void Update()
    {
        if (AILapsDone == PlayerPrefs.GetInt("Laps")){
        AIRaceFinish.SetActive(true);
        }
    }
    

    public void OnTriggerEnter(Collider AICar){
        if(AICar.tag == "AI_Car"){
            AILapsDone += 1;
        }

        HalfLapTrig.SetActive(true);
        LapCompleteTrig.SetActive(false);

    }
}

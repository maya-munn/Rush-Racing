using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Immanuel Siregar

public class HalfPointTrigger : MonoBehaviour
{

    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    //Works in conjunction with the Lap Completion trigger, as player moves through the halfway point, the halfway point is disabled and the Lap Complete trigger is activated.
    void OnTriggerEnter()
    {
        LapCompleteTrig.SetActive(true);
        HalfLapTrig.SetActive(false);
    }
}

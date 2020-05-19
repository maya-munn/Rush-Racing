using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceFinish : MonoBehaviour
{ 
    public GameObject StatsPanel;
    public GameObject TotalLapMins;
    public GameObject TotalLapSecs;
    public GameObject TotalLapMilli;
    // Update is called once per frame
    void OnTriggerEnter()
    {
        StatsPanel.SetActive(true);
    }
}

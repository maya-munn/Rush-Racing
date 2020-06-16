using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Immanuel Siregar

public class RaceFinish : MonoBehaviour
{ 
    public GameObject StatsPanel;
    public GameObject TotalLapMins;
    public GameObject TotalLapSecs;
    public GameObject TotalLapMilli;
    
    //Will put up the scoreboard when the Racefinish trigger is activated.
    void OnTriggerEnter()
    {
        StatsPanel.SetActive(true);
        gameObject.AddComponent<CurrencyTable>().AddToUserCurrency(500);
        
    }
}

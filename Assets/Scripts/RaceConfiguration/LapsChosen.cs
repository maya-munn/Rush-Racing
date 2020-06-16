using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// (Author): Bernadette Cruz
/// 
/// This script checks the number of laps chosen for FreePlay/Tournament Mode so that the number of laps can be loaded to the racing scenes.
/// </summary>
public class LapsChosen : MonoBehaviour
{
    public GameObject Laps; 
    void Update()
    {
        //Gets number of laps chosen
        int lapnumber = int.Parse(Laps.GetComponent<TextMeshProUGUI>().text);

        //Saves value of laps chosen to playerprefs so that it can before the race.
        PlayerPrefs.SetInt("Laps", lapnumber);

    }
}

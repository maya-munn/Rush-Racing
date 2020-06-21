using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Author: Bernadette Cruz
/// Allows the car's colour to be changed depending on player's choice in the Garage
/// </summary>
public class ChangeCarColor : MonoBehaviour
{
    public GameObject[] CarList;
   // public static GameObject ActiveCar;
    //public GameObject PlayerCarPrefab;
    void Start()
    {
        //Get different components of a certain colour (child objects)
        CarList = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            CarList[i] = transform.GetChild(i).gameObject;
        }


        //Activate chosen color and all its components depending on player's choice in the Garage
        for (int i = 0; i < transform.childCount; ++i)
        {
            CarList[PlayerPrefs.GetInt("CarSelected")].transform.GetChild(i).gameObject.SetActive(true); 
        }
     
    }

}
   

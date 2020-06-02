﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AwakeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Cars carlist;
    public int pointer_car;
    public GameObject Acquirebutton;
   
    public TextMeshProUGUI currency;
    public TextMeshProUGUI cardetail;

    private void Awake()
    {
        PlayerPrefs.SetInt("currency", 20000);
        pointer_car = PlayerPrefs.GetInt("pointer");
        currency.text = "$" + PlayerPrefs.GetInt("currency").ToString("");

        GameObject childObject = Instantiate(carlist.car[pointer_car], Vector3.zero, Quaternion.identity) as GameObject;
        childObject.tag = "player";
        GetCarDetail();
    }


    public void NextCarButton()
    {
        Destroy(GameObject.FindGameObjectWithTag("player"));

        if (pointer_car == carlist.car.Length - 1) pointer_car = 0;
        else pointer_car++;

        PlayerPrefs.SetInt("pointer", pointer_car);
        GameObject childObject = Instantiate(carlist.car[pointer_car], Vector3.zero, Quaternion.identity) as GameObject;
        childObject.tag = "player";
        GetCarDetail();
    }
    public void PreviousCarButton()
    {
        Destroy(GameObject.FindGameObjectWithTag("player"));

        if (pointer_car == 0) pointer_car = carlist.car.Length - 1;
        else pointer_car--;

        PlayerPrefs.SetInt("pointer", pointer_car);
        GameObject childObject = Instantiate(carlist.car[pointer_car], Vector3.zero, Quaternion.identity) as GameObject;
        childObject.tag = "player";
        GetCarDetail();
    }

    public void AcquireCar()
    {
        carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().acquire = true;
        if (PlayerPrefs.GetInt("currency") >= carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().price) {

            PlayerPrefs.SetString(carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().name.ToString(),
                                    carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().name.ToString());
            PlayerPrefs.GetInt("currency", PlayerPrefs.GetInt("currency") - carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().price);
        }
        GetCarDetail();
        currency.text = "$" + PlayerPrefs.GetInt("currency").ToString("");
    }
    public void GetCarDetail()
    {
        if (carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().name.ToString() ==
            PlayerPrefs.GetString(carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().name.ToString()))
            {
            Acquirebutton.SetActive(false);
            cardetail.text = carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().name.ToString();

        }
        else
        {
            Acquirebutton.SetActive(true);
            cardetail.text = carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().name.ToString() + carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().price.ToString();
 
        }
    }
}

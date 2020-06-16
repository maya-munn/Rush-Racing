using System;
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
       
        if (PlayerPrefs.GetInt("currency") >= carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().price) {

            PlayerPrefs.SetString(carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().getCarname(),
                                    carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().getCarname());
            PlayerPrefs.SetInt("currency", PlayerPrefs.GetInt("currency") - carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().price);
            Debug.Log(PlayerPrefs.GetInt("currency").ToString());
        }
        GetCarDetail();
        currency.text = "$" + PlayerPrefs.GetInt("currency").ToString("");
    }
    public void GetCarDetail()
    {
        Debug.Log(carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().getCarname());
        if (carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().getCarname() ==
            PlayerPrefs.GetString(carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().getCarname()))
            {
            Acquirebutton.SetActive(false);
            cardetail.text = carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().getCarname();

        }
        else
        {
            Acquirebutton.SetActive(true);
            cardetail.text = carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().getCarname() +"\n$"+ carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().price.ToString();
 
        }
    }
}

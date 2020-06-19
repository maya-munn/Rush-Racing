using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//      Author:         Henry Le

//      Description:    This script is using for changings and store cars modification 
//                      base on user selections, including buys and upgrades new cars
//                      or car parts

public class CarSelection : MonoBehaviour
{
    private int index;
    private GameObject[] carList;
    public TextMeshProUGUI currency;
    public Button AcquireButton;
    //Field for displaying Car Stats
    public TextMeshProUGUI Stats;


    //Display current chosen car
    private void Awake()
    {
        PlayerPrefs.SetInt("CurrentCoins", 30000);
        carList = new GameObject[transform.childCount];
        index = PlayerPrefs.GetInt("CarSelected", 0);
    }
    private void Start()
    {
        
        
        
        //Fill the arrays with models
        for(int i = 0; i < transform.childCount; i++)
        {
            carList[i] = transform.GetChild(i).gameObject;
        }
        //Hidden the model which is unselected
        foreach(GameObject car  in carList)
        {
            car.SetActive(false);
        }
        //Toggle car index
        if (carList[index])
        {
            carList[index].SetActive(true);
        }
       
    }
    private void OnGUI()
    {
        DisplayCarStats();
        DisplayButtonAcquire();
        currency.text = "$" + PlayerPrefs.GetInt("CurrentCoins").ToString();
    }

    public void ChangeCarOnClick(bool isLeft)
    {
        //Toggle off the current model
        carList[index].SetActive(false);

        //Make sure index is in car list range
        if (isLeft == true)
        {
            index--;
            if (index < 0)
            {
                index = carList.Length - 1;
            }
        }else
        {
            index++;
            if (index > carList.Length - 1)
            {
                index = 0;
            }
        }
        //Toggle new model
        carList[index].SetActive(true);
      
    }

     //Save Selected to PlayerPrefs for using in Play Mode
    public void OnSelected()
    {
        if (PlayerPrefs.GetInt(carList[index].GetComponent<CarStats>().CarName, 0) == 0) TryBuyCar();
        else PlayerPrefs.SetInt("CarSelected", index);
    }

    public void DisplayCarStats()
    {
        Stats.SetText(carList[index].GetComponent<CarStats>().CarName
                + '\n' + carList[index].GetComponent<CarStats>().CarPrice);
    }

    public void DisplayButtonAcquire()
    {
        // if car have been bought
        if (PlayerPrefs.GetInt(carList[index].GetComponent<CarStats>().CarName) == 1)
        {
            //Button is display "Selected" text if already select
            if (PlayerPrefs.GetInt("CarSelected") == index)
            {
                AcquireButton.GetComponentInChildren<TextMeshProUGUI>().text = "Selected";
                AcquireButton.interactable = false;
            }
            else { AcquireButton.GetComponentInChildren<TextMeshProUGUI>().text = "Select"; AcquireButton.interactable = true; }
        }
        else //if car havnt been bought
        {
            if (!canBuy())
            {
                AcquireButton.GetComponentInChildren<TextMeshProUGUI>().text = "Insufficient money";
                AcquireButton.interactable = false;
            }
            else
            {
                AcquireButton.GetComponentInChildren<TextMeshProUGUI>().text = "Purchase";
                AcquireButton.interactable = true;
            }
        }
    }

    public void TryBuyCar()
    {
        if (canBuy())
        {
            PlayerPrefs.SetInt(carList[index].GetComponent<CarStats>().CarName, 1);
            gameObject.AddComponent<CurrencyTable>().RemoveFromUserCurrency(carList[index].GetComponent<CarStats>().CarPrice);

            PlayerPrefs.SetInt("CurrentCoins", gameObject.GetComponent<CurrencyTable>().GetUserCurrency()); 
        }
    }

    public bool canBuy()
    {
        return PlayerPrefs.GetInt("CurrentCoins") >= carList[index].GetComponent<CarStats>().CarPrice;
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AwakeManager : MonoBehaviour
{
    public Cars carlist;
    public int pointer_car;
    public GameObject Acquirebutton;
   
    public TextMeshProUGUI currency;
    public TextMeshProUGUI cardetail;

    private void Awake()
    {
        pointer_car = PlayerPrefs.GetInt("pointer");
        currency.text = "$" + PlayerPrefs.GetInt("CurrentUserCoins").ToString("");

        GameObject childObject = Instantiate(carlist.car[pointer_car], Vector3.zero, Quaternion.identity) as GameObject;
        childObject.tag = "player";
        GetCarDetail();

        this.CheckIfCanAfford(); //Toggle AQUIRE button if can/can't afford
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

        this.CheckIfCanAfford(); //Toggle AQUIRE button if can/can't afford
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

        this.CheckIfCanAfford(); //Toggle AQUIRE button if can/can't afford
    }

    public void AcquireCar()
    {
       
        if (PlayerPrefs.GetInt("CurrentUserCoins") >= carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().price) {

            PlayerPrefs.SetString(carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().getCarname(),
                                    carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().getCarname());
            PlayerPrefs.SetInt("CurrentUserCoins", PlayerPrefs.GetInt("CurrentUserCoins") - carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().price);
            //Debug.Log(PlayerPrefs.GetInt("CurrentUserCoins").ToString());
        }
        GetCarDetail();
        currency.text = "$" + PlayerPrefs.GetInt("CurrentUserCoins").ToString("");
    }
    public void GetCarDetail()
    {
        //Debug.Log(carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().getCarname());
        if (carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().getCarname() ==
            PlayerPrefs.GetString(carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().getCarname()))
            {
            //Acquirebutton.SetActive(false);
            cardetail.text = carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().getCarname() + " $" + carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().GetCarPrice();

        }
        else
        {
            //Acquirebutton.SetActive(true);
            cardetail.text = carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().getCarname() +": $"+ carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().price.ToString();
 
        }
    }

    /// <summary>
    /// Toggles the aquire button to OFF if the user cant afford the car
    /// Author: Maya Ashizumi-Munn
    /// </summary>
    private void CheckIfCanAfford()
    {
        int carPrice = carlist.car[PlayerPrefs.GetInt("pointer")].GetComponent<CarDetail>().price;
        int userBalance = PlayerPrefs.GetInt("CurrentUserCoins");
        if (carPrice > userBalance)
        {
            //Make button unavailable
            Acquirebutton.GetComponent<Button>().interactable = false;
        }
        else
        {
            //Can afford, make available
            Acquirebutton.GetComponent<Button>().interactable = true;
        }
    }
}

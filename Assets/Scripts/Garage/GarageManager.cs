using TMPro;
using UnityEngine;
using UnityEngine.UI;

//      Author:         Henry Le

//      Description:    This script is using for changings and store cars modification 
//                      base on user selections, including buys and upgrades new cars
//                      or car parts

public class GarageManager : MonoBehaviour
{
    private int index;
    public GameObject Player;
    private GameObject[] carList;
    public TextMeshProUGUI currency;
    public Button AcquireButton;
    //Field for displaying Car Stats
    public TextMeshProUGUI CarName;
    public TextMeshProUGUI CarPrice;

    //Colors Modification
    public Transform colorPanel;
    public Color[] carColors = new Color[5];

    public Button ColorApplyButton;

    //Display current chosen car
    private void Awake()
    {
        PlayerPrefs.SetInt("CurrentCoins", 30000);
        index = PlayerPrefs.GetInt("CarSelected", 0);
        carList = Player.GetComponent<SpawnCar>().carList;
        InitColorPanel();
    }
    private void OnGUI()
    {
        DisplayCarStats();
        DisplayButtonAcquire();
        currency.text = "$ " + PlayerPrefs.GetInt("CurrentCoins", 0).ToString();
    }
    //
    //need add button on click to show shop
    private void InitColorPanel()
    {
        if(colorPanel == null)
        {
            Debug.Log("Please asign the color panel in the inspector.");
        }
        //change color for all children in color panel
        int i = 0;
        foreach (Transform color in colorPanel)
        {
            int currentIndex = i;
            Button colorButton = color.GetComponent<Button>();
            colorButton.onClick.AddListener(() => OnColorSelect(currentIndex));

            //Set Color of the image
            Image ColorImg = colorButton.GetComponent<Image>();
            ColorImg.color = carColors[currentIndex];

            i++;
        }
        //Reset index
        i = 0;
    }

    public void OnColorSelect(int currentIndex)
    {
        carList[index].GetComponent<CarStats>().material.SetColor("_Color",carColors[currentIndex]);
    }
    public void onColorApply()
    {
        Debug.Log("Buy Color");
    }

    public void ChangeCarOnClick(bool isLeft)
    {
        //Destroy the current model
        Destroy(GameObject.FindGameObjectWithTag("Player"));

        //Make sure index is in car list range
        if (isLeft == true)
        {
            index--;
            if (index < 0)
            {
                index = carList.Length - 1;
            }
        }
        else
        {
            index++;
            if (index > carList.Length - 1)
            {
                index = 0;
            }
        }
       //Instantiate new model
        Instantiate(carList[index], Player.transform.position, Player.transform.rotation);

    }

    //Save Selected to PlayerPrefs for using in Play Mode
    public void OnSelected()
    {
        if (PlayerPrefs.GetInt(carList[index].GetComponent<CarStats>().CarName, 0) == 0) TryBuyCar();
        else PlayerPrefs.SetInt("CarSelected", index);
    }

    public void DisplayCarStats()
    {
        CarName.SetText(carList[index].GetComponent<CarStats>().CarName);
        CarPrice.SetText("$ " + carList[index].GetComponent<CarStats>().CarPrice.ToString());
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
                AcquireButton.GetComponentInChildren<TextMeshProUGUI>().text = "Insufficient";
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

            PlayerPrefs.SetInt("CurrentCoins", PlayerPrefs.GetInt("CurrentCoins", 0) - carList[index].GetComponent<CarStats>().CarPrice);
        }
    }

    public bool canBuy()
    {
        return PlayerPrefs.GetInt("CurrentCoins", 0) >= carList[index].GetComponent<CarStats>().CarPrice;
    }
}

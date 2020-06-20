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
    public TextMeshProUGUI speed;
    public TextMeshProUGUI upgradeCost;


    //Colors Modification
    public GameObject colorPanel;
    public Color[] carColors = new Color[5];
    

    //Button upgrade
    public GameObject showColor;
    public GameObject showUpgrade;

    public GameObject upgradePanel;
    public Button upgradeSpeedButton;
    //Display current chosen car
    private void Awake()
    {
        PlayerPrefs.SetInt("CurrentCoins", 30000);
        index = PlayerPrefs.GetInt("CarSelected", 0);
        carList = Player.GetComponent<SpawnCar>().carList;
        
        InitColorPanel();
        InitSlider();
    }
    private void OnGUI()
    {
        speed.text = carList[index].GetComponent<CarStats>().speed.ToString()
            + "/" + carList[index].GetComponent<CarStats>().maxSpeed.ToString();
        upgradeCost.text = "Upgrade cost: "
            + carList[index].GetComponent<CarStats>().upgradeCost.ToString();
        DisplayCarStats();
        DisplayButtonAcquire();
        currency.text = "$ " + PlayerPrefs.GetInt("CurrentCoins", 0).ToString();

        //disable upgrade and color if car havnt been bought
        if(PlayerPrefs.GetInt(carList[index].GetComponent<CarStats>().CarName) == 0)
        {
            showColor.SetActive(false);
            showUpgrade.SetActive(false);
        }
        else {
            showColor.SetActive(true);
            showUpgrade.SetActive(true);
        }
        //disable upgrade speed button if dont have enough  money to upgrade
        if (PlayerPrefs.GetInt("CurrentCoins", 0) < carList[index].GetComponent<CarStats>().upgradeCost)
        {
            upgradeSpeedButton.interactable = false;
        }
        else upgradeSpeedButton.interactable = true;
    }
    //
    //need add button on click to show shop
    private void InitColorPanel()
    {
        if(colorPanel.transform == null)
        {
            Debug.Log("Please asign the color panel in the inspector.");
        }
        //change color for all children in color panel
        int i = 0;
        foreach (Transform color in colorPanel.transform)
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
    //Change Car Color
    public void OnColorSelect(int currentIndex)
    {
        carList[index].GetComponent<CarStats>().material.SetColor("_Color",carColors[currentIndex]);
    }
    //Show color panel while mouse enter color button
    public void onColorEnter(bool isEnter)
    {
        if (isEnter)
        {
            colorPanel.SetActive(true);
        }
        else colorPanel.SetActive(false);
    }
    //Show Upgrade panel while mouse enter upgrade button
    public void onUpgradeEnter(bool isEnter)
    {
        if (isEnter)
        {
            upgradePanel.SetActive(true);
        }
        else upgradePanel.SetActive(false);
    }

    //Stats Bar

    public Slider speedSlider;
    public void InitSlider()
    {
        speedSlider.maxValue = carList[index].GetComponent<CarStats>().maxSpeed;
        speedSlider.value = carList[index].GetComponent<CarStats>().speed;
        Debug.Log("Slider init");
    }
    public void upgradeSpeed()
    {
        //Set speed = max speed if upgrade exceed max speed
        if ((carList[index].GetComponent<CarStats>().speed
            + carList[index].GetComponent<CarStats>().upgradeSpeed)
            >= carList[index].GetComponent<CarStats>().maxSpeed)
        {
            carList[index].GetComponent<CarStats>().speed = carList[index].GetComponent<CarStats>().maxSpeed;
            speedSlider.value = carList[index].GetComponent<CarStats>().maxSpeed;
        }
        else {
            speedSlider.value += carList[index].GetComponent<CarStats>().upgradeSpeed;
            carList[index].GetComponent<CarStats>().speed += carList[index].GetComponent<CarStats>().upgradeSpeed;
        }
        PlayerPrefs.SetInt("CurrentCoins", PlayerPrefs.GetInt("CurrentCoins")-carList[index].GetComponent<CarStats>().upgradeCost);
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
       GameObject Car= Instantiate(carList[index], Player.transform.position, Player.transform.rotation);
        Car.transform.parent = Player.transform;
        InitSlider();
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
        //Display car price if it havent bought
        if (PlayerPrefs.GetInt(carList[index].GetComponent<CarStats>().CarName) == 0)
        {
            CarPrice.SetText("$ " + carList[index].GetComponent<CarStats>().CarPrice.ToString());
        }
        else
        {
            CarPrice.SetText("Owned");
        }
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

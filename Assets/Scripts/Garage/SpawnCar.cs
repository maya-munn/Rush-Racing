using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject[] carList;
    private void Awake()
    {
        Instantiate(carList[PlayerPrefs.GetInt("CarSelected")], this.transform.position, this.transform.rotation);
    }
}

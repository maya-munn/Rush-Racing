using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject[] carList;
    private void Awake()
    {
        GameObject Player=Instantiate(carList[PlayerPrefs.GetInt("CarSelected")], this.transform.position, this.transform.rotation);
        Player.transform.parent = gameObject.transform;
    }
}

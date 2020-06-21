using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarControlActive : MonoBehaviour
{   
     public GameObject Car;
    // Start is called before the first frame update
    void Start() 
    {
        Car.GetComponent<CarController>().enabled = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDetail : MonoBehaviour
{

    public int price;
    public string car_name;

    public string getCarname()
    {
        return car_name;
    }

    /// <summary>
    /// Gets the cars price
    /// Author: Maya Ashizumi-Munn
    /// </summary>
    /// <returns>The price of the car: integer</returns>
    public int GetCarPrice()
    {
        return this.price;
    }
}

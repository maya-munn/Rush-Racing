using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Immanuel Siregar
//credit besnik on youtube for the sprites 
public class SpeedoManager : MonoBehaviour
{
    public GameObject needle;

    //The positions of the needle at 0 km/h, and 180 km/h respectively.
    private float startPos = 220f;
    private float endPos = -46f;
    private float currentPos;
    public float carSpeed;
    public CarController carController;

    // A speed variable created in the CarController script, made with rigidbody.velocity.magnitude
    void FixedUpdate()
    {
        carSpeed = carController.speed;
        updateNeedle();
    }

   
    //How the needle will be mapped. The original speed variable will be in meters per second, so the temp variable will adjust that.
    public void updateNeedle()
    {
        currentPos = startPos - endPos;
        float temp = (carSpeed*3.6f) / 180;
        needle.transform.eulerAngles = new Vector3(0, 0, (startPos - temp * currentPos));
    }
}

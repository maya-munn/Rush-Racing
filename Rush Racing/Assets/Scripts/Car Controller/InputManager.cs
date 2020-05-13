using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles any key inputs by the user and translates them into car movements and actions
/// Author: Maya Ashizumi-Munn
/// </summary>
public class InputManager : MonoBehaviour { 

    public float throttle;
    public float steer;
    public bool lights;
    public bool brake;

    // Update is called once per frame
    void Update()
    {
        //Handle steering and throttle based on user input
        throttle = Input.GetAxis("Vertical");
        steer = Input.GetAxis("Horizontal");

        //Toggles lights when L key pressed
        lights = Input.GetKeyDown(KeyCode.L);

        //Makes the vehicle lock its brakes when the space button is pressed
        brake = Input.GetKey(KeyCode.Space);
    }
}

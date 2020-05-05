using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the headlights being on and off for the vehicle
/// This script is triggered from the car controller class
/// Author: Maya Ashizumi-Munn
/// </summary>
public class LightingManager : MonoBehaviour
{
    public List<Light> headLights;

    public virtual void ToggleHeadlights()
    {
        //Turn on and off headlights 
        foreach(Light light in headLights)
        {
            //When toggle headlights method is called, if intensity is 0 (turned off), change it to 4 (turned on) and vice versa
            light.intensity = light.intensity == 0 ? 4 : 0;
        }
    }

}

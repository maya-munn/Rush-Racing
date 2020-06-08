using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Author: Immanuel Siregar
//This simple script allows the car to change the UI position display accordingly when the AI car passes the player's position and vice versa.

public class PositionBehind : MonoBehaviour
{   
    //This gameobject is the text label in the UI showing the postion of the car
    public GameObject PosDisplay;

    //The only gameobject with the tag "position" is the position trigger carried by the player's car
    void OnTriggerExit(Collider collisionObject){
        if (collisionObject.tag == "Position"){
            PosDisplay.GetComponent<Text>().text = "2nd";
        } 
    }   
}

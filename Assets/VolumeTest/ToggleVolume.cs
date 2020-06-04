using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/*  Authors: Bernadette Cruz
 *  Checks if checkbox "Mute Volume" is toggled on and off
 *  mutes and removes slider interactability if checked, unmutes to previous slider value if unchecked.

 * ----FUTURE IMPLEMENTATIONS: Mute volume according to saved user settings
 */

public class ToggleVolume : MonoBehaviour
{   public AudioMixer mainMixer;
    public Slider slider;
    public float prevValue;

    void Start()
    {  
       prevValue = slider.value;
       ToggleChange(GetComponent<Toggle>().isOn);
    }
    public void ToggleChange(bool toggle)
    {
        toggle = gameObject.GetComponent<Toggle>().isOn;
         if(toggle)
         {   prevValue = slider.value;            
             slider.interactable = false; 
             slider.value = 0.0f;
         }
         else if(!toggle)
         {
             slider.value = prevValue;
             slider.interactable = true;
         }
    }


}

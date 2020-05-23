using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/*  <summary>
*    This script allows the music volume levels to be changed when the slider is dragged.
 *   Log10 is used because the audio mixer value is logarithmic: Unity's default slider is too sensitive (e.g. sliding volume from 100% to 50% is too quiet) 
 *   Authors: Bernadette Cruz
 *
 *  </summary>
 *    -----FUTURE IMPLEMENTATIONS: -Save volume slider values (to Playerprefs or DB?) to load in-game when saved in settings page
 */

public class SetVolume : MonoBehaviour
{
    public AudioMixer mainMixer;
    
    void Start()
    {
        mainMixer.SetFloat("MusicVolume", Mathf.Log10(GetComponent<Slider>().value)*20);
    }
    public void SetLevel(float sliderValue)
    {
        mainMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20); 
    }
}

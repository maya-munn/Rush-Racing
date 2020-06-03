using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Author: Immanuel Siregar
//This code is borrowed from JimmyVegas, who had created a timer system for laps in his video series documenting the creation of a racing game.

public class LapTimeManager : MonoBehaviour
{


	public static int MinuteCount;
	public static int SecondCount;
	public static float MilliCount;
	public static string MilliDisplay;

	public GameObject MinuteBox;
	public GameObject SecondBox;
	public GameObject MilliBox;

	public int SecondCountTesting;

	public void Update()
	{
		//Delta time is the time between frames: MilliCount will count Milliseconds which happen to take 10 frames of gameplay.
		MilliCount += Time.deltaTime * 10;

		//Converts Millisecond count to a string, so that it can be placed in the MilliBox GameObject.
		MilliDisplay = MilliCount.ToString("F0");
		MilliBox.GetComponent<Text>().text = "" + MilliDisplay;

		//The next several if statements will allow the digits in the Millisecond, Second, and Minute Counter to work together and form a functioning timer. If 10 milliseconds have passed, it resets MilliCount to 0 and adds SecondCount to 1. It is the same way with 60 SecondCount into 1 MinuteCount.
		if (MilliCount >= 9)
		{
			MilliCount = 0;
			SecondCount += 1;
			SecondCountTesting+=1;
		}

		if (SecondCount <= 9)
		{
			SecondBox.GetComponent<Text>().text = "0" + SecondCount + ".";
		}
		else
		{
			SecondBox.GetComponent<Text>().text = "" + SecondCount + ".";
		}

		if (SecondCount >= 60)
		{
			SecondCount = 0;
			MinuteCount += 1;
		}


		if (MinuteCount <= 9)
		{
			MinuteBox.GetComponent<Text>().text = "0" + MinuteCount + ":";
		}
		else
		{
			MinuteBox.GetComponent<Text>().text = "" + MinuteCount + ":";
		}

	}
}

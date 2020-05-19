using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalLapTime : MonoBehaviour
{
    public static int TotalMinCount;
	public static int TotalSecCount;
	public static float TotalMilliCount;
	public static string TotalMilliDisplay;    
    
    public GameObject TotalMinBox;
	public GameObject TotalSecBox;
	public GameObject TotalMilliBox;

	public static float RawTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TotalMilliCount += Time.deltaTime * 10;
		RawTime += Time.deltaTime;
		TotalMilliDisplay = TotalMilliCount.ToString("F0");
        TotalMilliBox.GetComponent<Text>().text = "" + TotalMilliDisplay;

        if (TotalMilliCount >= 9)
		{
			TotalMilliCount = 0;
			TotalSecCount += 1;
		}

        if (TotalSecCount <= 9)
		{
			TotalSecBox.GetComponent<Text>().text = "0" + TotalSecCount + ".";
		}else{
			TotalSecBox.GetComponent<Text>().text = "" + TotalSecCount + ".";
		}

        if (TotalSecCount >= 60)
		{
			TotalSecCount = 0;
			TotalMinCount += 1;
		}

		if (TotalMinCount <= 9)
		{
			TotalMinBox.GetComponent<Text>().text = "0" + TotalMinCount + ":";
		}else{
			TotalMinBox.GetComponent<Text>().text = "0" + TotalMinCount + ":";
		}


    }
}

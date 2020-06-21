using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerForAI : MonoBehaviour
{
    public static int AIMinCount;
	public static int AISecCount;
	public static float AIMilliCount;
    public static string AIMilliDisplay;    

    public GameObject AIMinBox;
    public GameObject AISecBox;
    public GameObject AIMilliBox; 

    public static float RawTime;

    void Update(){
        AIMilliCount += Time.deltaTime * 10;
        RawTime += Time.deltaTime;

        AIMilliDisplay = AIMilliCount.ToString("F0");
        AIMilliBox.GetComponent<Text>().text = "" + AIMilliDisplay;

        if(AIMilliCount >= 9){
            AIMilliCount = 0;
            AISecCount += 1;
        }

        if (AISecCount <= 9)
		{
			AISecBox.GetComponent<Text>().text = "0" + AISecCount + ".";
		}else{
			AISecBox.GetComponent<Text>().text = "" + AISecCount + ".";
		}

        if (AISecCount >= 60)
		{
			AISecCount = 0;
			AIMinCount += 1;
		}

        if (AIMinCount <= 9)
		{
			AIMinBox.GetComponent<Text>().text = "0" + AIMinCount + ":";
		}else{
			AIMinBox.GetComponent<Text>().text = "0" + AIMinCount + ":";
		}
    }

}

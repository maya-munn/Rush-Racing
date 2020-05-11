using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HorizontalSelector : MonoBehaviour
{

    private TextMeshProUGUI text;
    public List<string> maplist = new List<string>();
    public int index = 0;
    void Start()
    {
        text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        Debug.Log(maplist.Count);
        transform.Find("ButtonPrevious").GetComponent<Button>().onClick.AddListener(PreviousMap);
        transform.Find("ButtonNext").GetComponent<Button>().onClick.AddListener(NextMap);
       
    }

    void PreviousMap()
    {
        if (index == 0)
        {
            index = maplist.Count - 1;
        }
        else index--;

        text.text = maplist[index];
    }

    void NextMap()
    {
        if ((index+1) >= maplist.Count)
        {
            index = 0;
        }
        else index++;
        text.text = maplist[index];
    }

}


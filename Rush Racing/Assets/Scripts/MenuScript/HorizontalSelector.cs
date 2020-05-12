using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.UI;

using Object = UnityEngine.Object;

public class HorizontalSelector : MonoBehaviour
{

    private TextMeshProUGUI text;
    private RawImage image;

    private Object defaultobject;
    private List<Object> defaultList = new List<Object>();

    private int index = 0;


    [Serializable]
    public class MapList
    {
        public string MapListName;
        public Texture MapListImage;

    }

    [SerializeField] public List<MapList> ObjectList = new List<MapList>();


    void Start()
    {


        text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        if ( transform.Find("Image"))
        {
            image = transform.Find("Image").GetComponent<RawImage>();
        }

        // Debug.Log(MapListName.Count);

        transform.Find("ButtonPrevious").GetComponent<Button>().onClick.AddListener(Previous);
        transform.Find("ButtonNext").GetComponent<Button>().onClick.AddListener(Next);

    }

    void Previous()
    {
        if (index == 0)
        {
            index = ObjectList.Count - 1;
        }
        else index--;
        if (transform.Find("Image"))
        {
            image.texture = ObjectList[index].MapListImage;
        }
        text.text = ObjectList[index].MapListName;
    }

    void Next()
    {
        if ((index + 1) >= ObjectList.Count)
        {
            index = 0;
        }
        else index++;
        if (transform.Find("Image"))
        {
            image.texture = ObjectList[index].MapListImage;
        }
        text.text = ObjectList[index].MapListName;
    }
}

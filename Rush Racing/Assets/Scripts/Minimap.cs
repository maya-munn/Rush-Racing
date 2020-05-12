using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*  
* This script stabilies the minimap camera to prevent cam from flipping over if car flips over
*/
public class Minimap : MonoBehaviour
{   public GameObject Car;
    public float y;

    void LateUpdate()
    {  
       float xe = Car.transform.position.x;
       float ze = Car.transform.position.z;
        y = Car.transform.eulerAngles.y;
        transform.position = new Vector3(xe, transform.position.y, ze);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, y, 0);
    }
}

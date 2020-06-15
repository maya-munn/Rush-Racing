using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*  Script by: Bernadette Cruz 
*   This script allows the camera to follow the car's minimap tracker
    andstabilises the camera to prevent it from flipping over
*/
public class Minimap : MonoBehaviour
{   public GameObject Target;
    public float y;

    void LateUpdate()
    {  
       float xe = Target.transform.position.x;
       float ze = Target.transform.position.z;
        y = Target.transform.eulerAngles.y;
        transform.position = new Vector3(xe, transform.position.y, ze);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, y, 0);
    }
}

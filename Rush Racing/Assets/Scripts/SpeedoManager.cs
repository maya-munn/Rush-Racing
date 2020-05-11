using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//CHANGE EVERYTHING BASED ON STRENGTHCOEFFICIENT TO A MORE DYNAMIC SPEED VARIABLE (rigidbody.veliocity.magnitude)
//credit besnik on youtube for the sprites and code configuration
public class SpeedoManager : MonoBehaviour
{
    public GameObject needle;
    private float startPos = 220f;
    private float endPos = -46f;
    private float currentPos;
    public float carSpeed;
    public CarController RR;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        carSpeed = RR.strengthCoefficient;
        updateNeedle();
    }

   

    public void updateNeedle()
    {
        currentPos = startPos - endPos;
        float temp = (carSpeed - 19800) / 180;
        needle.transform.eulerAngles = new Vector3(0, 0, (startPos - temp * currentPos));
    }
}

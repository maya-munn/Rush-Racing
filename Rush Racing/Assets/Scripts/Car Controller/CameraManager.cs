using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by Maya Ashizumi-Munn with help from Unity Car Physics Tutorial - #2 Axiomatic Uncertainty Youtube
public class CameraManager : MonoBehaviour
{
    public GameObject focus;    //Thing that will be focused on at all times (vehicle)
    public float distance = 5f; //Distance from vehicle to camera
    public float height = 2f;
    public float dampening = 1f;

    // Update is called once per frame
    void Update()
    {
        Vector3 secondVector = focus.transform.position + focus.transform.TransformDirection(new Vector3(0f, height, -distance));
        transform.position = Vector3.Lerp(transform.position, secondVector, dampening * Time.deltaTime);    //Linear interpolation between two vectors
        transform.LookAt(focus.transform); //Force camera to point directly at transform
    }
}

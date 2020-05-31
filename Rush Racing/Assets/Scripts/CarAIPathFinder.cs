using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAIPathFinder : MonoBehaviour
{
    public Transform carPath;
    private List<Transform> pathPoints;
    private int currentPoint = 0;
    public float maxSteerAngle = 45f;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;

    void Start()
    {
        Transform[] pathPositions = carPath.GetComponentsInChildren<Transform>();
        pathPoints = new List<Transform>();
        
        for(int i = 0; i < pathPositions.Length; i++){
            if(pathPositions[i] != carPath.transform){
                pathPoints.Add(pathPositions[i]);
            }
        }
    }

    void FixedUpdate(){
        CarSteer();
        CarDrive();
        CarNavigation();
    }

    private void CarSteer(){
        Vector3 travelVect = transform.InverseTransformPoint(pathPoints[currentPoint].position);
        travelVect = travelVect / travelVect.magnitude;
        float newSteer = (travelVect.x / travelVect.magnitude)* maxSteerAngle;
        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;
    }

    void CarDrive(){
        wheelFL.motorTorque = 500f;
        wheelFR.motorTorque = 500f;
    }

    void CarNavigation(){
        if(Vector3.Distance(transform.position, pathPoints[currentPoint].position) < 0.05f){
            if(currentPoint == pathPoints.Count - 1){
                currentPoint = 0;
            } else{
                currentPoint++;
            }
        }
    }
}

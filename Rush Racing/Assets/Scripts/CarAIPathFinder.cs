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

    //Gets all the waypoints from the CarPathAI script.
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

    //Allows the car to turn/rotate according to the vector of the next waypoint.
    private void CarSteer(){
        Vector3 travelVect = transform.InverseTransformPoint(pathPoints[currentPoint].position);
        travelVect = travelVect / travelVect.magnitude;
        float newSteer = (travelVect.x / travelVect.magnitude)* maxSteerAngle;
        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;
    }

    //Allows the car to start moving by itself
    void CarDrive(){
        wheelFL.motorTorque = 211000f;
        wheelFR.motorTorque = 211000f;
    }

    //Makes the car follow the next waypoint once it has gotten near the first one.
    void CarNavigation(){
        if(Vector3.Distance(transform.position, pathPoints[currentPoint].position) < 2f){
            if(currentPoint == pathPoints.Count - 1){
                currentPoint = 0;
            } else{
                currentPoint++;
            }
        }
    }
}

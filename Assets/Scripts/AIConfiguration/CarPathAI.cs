using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Immanuel Siregar
//This will simply create a series of path points for the AI car to move through.
public class CarPathAI : MonoBehaviour{

    public Color pathColor;

    //A list holding positions around the track which the AI will traverse.
    private List<Transform> pathPoints = new List<Transform>();

    //Will set the color for the path which will be viewed in editor mode.
    void OnDrawGizmos(){
        Gizmos.color = pathColor;

    //This array holds all the positions of the path in which the Car AI will traverse.
        Transform[] pathPositions = GetComponentsInChildren<Transform>();
        pathPoints = new List<Transform>();
        
        for(int i = 0; i < pathPositions.Length; i++){
            if(pathPositions[i] != transform){
                pathPoints.Add(pathPositions[i]);
            }
        }

        //Sets the positions of the path points, draws a line between them and draws a sphere on each point
        for(int j = 0; j < pathPoints.Count; j++){
            Vector3 currentPoint = pathPoints[j].position;
            Vector3 prevPoint = Vector3.zero;
            if(j>0){
                prevPoint = pathPoints[j - 1].position;
            } else if(j == 0 && pathPoints.Count > 1){
                prevPoint = pathPoints[pathPoints.Count - 1].position;
            }
            
            Gizmos.DrawLine(prevPoint, currentPoint);
            Gizmos.DrawWireSphere(currentPoint, 0.5f);
        }
    }
}

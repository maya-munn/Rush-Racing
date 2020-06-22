using UnityEngine;

/// <summary>
/// Spawn point assigner to a player
/// Author: Maya Ashizumi-Munn
/// </summary>
public class PlayerSpawnPoint : MonoBehaviour
{
    //Add spawn point to list
    private void Awake() => PlayerSpawnSystem.AddSpawnPoint(transform);
    //Remove spawn point to list
    private void OnDestroy() => PlayerSpawnSystem.RemoveSpawnPoint(transform);

    //Happens only in the unity editor when looking at the scene - used for setting up
    private void OnDrawGizmos()
    {
        //Draw a blue sphere at the position of the object (spawn point)
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 1f); //Radius of 1

        //Drawing a green line from origin position to 2 positions in front
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2);
    }
}

using Cinemachine;
using Mirror;
using UnityEngine;

/// <summary>
/// Handles camera controls/viewing for each client on multiplayer
/// Author: Maya Ashizumi-Munn
/// </summary>
public class PlayerCameraController : NetworkBehaviour
{
    [Header("Camera")]
    public GameObject playerCamera = null;

    [Client]
    public override void OnStartAuthority()
    {
        playerCamera.gameObject.SetActive(true);
        enabled = true; //Only enable clients camera
    }

    public void Start()
    {
        //Do nothing, only here to disable script
    }
}

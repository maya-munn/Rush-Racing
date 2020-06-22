using System.Collections.Generic;
using UnityEngine;
using Mirror;

/// <summary>
///             CODE REUSED AND ADAPTED FROM CarController.cs
/// Main class for multiplayer vehicle control. Handles input from the InputManager then 
/// Author: Maya Ashizumi-Munn
/// 
/// Credit to AxiomaticUncertainty on YouTube for the Unity Car Physics tutorial which
/// this class and all other car handling classes were inspired from.
/// </summary>

//Dependency on input manager - script cannot function without this
[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(LightingManager))]
public class MultiplayerCarController : NetworkBehaviour
{
    public InputManager im;
    public LightingManager lm;

    public List<WheelCollider> throttleWheels;
    public List<GameObject> steeringWheels;
    public List<GameObject> meshes; //Contain all wheel meshes
    public List<GameObject> tailLights;

    public float strengthCoefficient = 20000f;  //Torque
    public float brakeStrength;                 //Strength of braking (brake torque)
    public float maxTurn = 20f;                 //Degrees
    public float speed;

    public Transform centreOfMass;              //Centre of mass
    public Rigidbody rigidBody;

    public Material brakePressedMat;
    public Material normalRearLightMat;

    public override void OnStartAuthority()
    {
        //Enable this object
        enabled = true;

        //Input manager reference to translate into car manipulation
        im = GetComponent<InputManager>();
        //Car object to manipulate
        rigidBody = GetComponent<Rigidbody>();

        //Setting centre of mass to the cars local position
        if (centreOfMass)
        {
            rigidBody.centerOfMass = centreOfMass.localPosition;
        }

        base.OnStartAuthority();
    }

    [ClientCallback]
    private void Update()
    {

        //If lights L key has been pressed, toggle headlights
        if (im.lights)
        {
            lm.ToggleHeadlights();
        }

        foreach (GameObject tailLight in tailLights)
        {
            //For normal cars, changing the colour will work
            //tailLight.GetComponent<Renderer>().material.SetColor("_EmissionColor", im.brake ? new Color(0.5f, 0.111f, 0.111f) : new Color(0f, 0f, 0f));

            //Lamborghini Huracan, need to change the material color directly
            tailLight.GetComponent<MeshRenderer>().material = (im.brake ? brakePressedMat : normalRearLightMat);
        }
    }

    [Client]
    //Handles all physics functions
    private void FixedUpdate()
    {
        //Handles multiplayer movement only for the players car, not all the player entities
        if (!hasAuthority) { return; }

        //Physics for verical car movement
        foreach (WheelCollider wheel in throttleWheels)
        {
            if (im.brake)
            {
                //If brake button is pressed, stop the car'
                wheel.motorTorque = 0f; //If braking, do not set any drive forward movement
                wheel.brakeTorque = brakeStrength;
            }
            else
            {
                //If not braking, move the car
                wheel.motorTorque = (strengthCoefficient * Time.deltaTime * im.throttle) * 2;
                wheel.brakeTorque = 0f; //If driving, do not set any brake
            }
        }

        //Physics for horizontal car movement
        foreach (GameObject wheel in steeringWheels)
        {
            //Get the angle of turn when the wheels are steered another direction than straight
            wheel.GetComponent<WheelCollider>().steerAngle = maxTurn * im.steer;
            //Changes the Y-axis of wheels to simulate the wheel steering in the specified direction
            wheel.transform.localEulerAngles = new Vector3(0f, im.steer * maxTurn, 0f);
            ////Get the angle of turn when the wheels are steered another direction than straight
            //wheel.GetComponent<WheelCollider>().steerAngle = maxTurn * im.steer;               
            ////Changes the Y-axis of wheels to simulate the wheel steering in the specified direction
            //wheel.transform.localEulerAngles = new Vector3(0f, im.steer * maxTurn, 0f);

            //Custom for lamborghini

            //Get the angle of turn when the wheels are steered another direction than straight
            wheel.GetComponent<WheelCollider>().steerAngle = maxTurn * im.steer;

            //Changes the Y-axis of wheels to simulate the wheel steering in the specified direction
            wheel.transform.localEulerAngles = new Vector3(-90f, im.steer * maxTurn, 90f);
        }

        //For each of our meshes, we need to change the rotate to simulate wheel spinning
        foreach (GameObject mesh in meshes)
        {
            ////Math for wheel rotation accordingly to speed
            //float magnitude = rigidBody.velocity.magnitude; //metres per second
            //float circumference = 2 * Mathf.PI * 0.33f; //circumference of any wheel. 0.33 is default radius for wheel
            //float direction = transform.InverseTransformDirection(rigidBody.velocity).z >= 0 ? 1 : -1; //Ternary operator to get direction of movement (backwards or forwards)
            //speed = rigidBody.velocity.magnitude; //speed to be called from speedometer manager
            ////X axis controls rotation, therefore y and z will be blank
            //mesh.transform.Rotate(magnitude * direction / circumference, 0f, 0f);

            //Custom rotation control for lamborghini huracan

            //Math for wheel rotation accordingly to speed
            float magnitude = rigidBody.velocity.magnitude; //metres per second
            float circumference = 2 * Mathf.PI * 0.33f; //circumference of any wheel. 0.33 is default radius for wheel
            float direction = transform.InverseTransformDirection(rigidBody.velocity).z >= 0 ? -1 : 1; //Ternary operator to get direction of movement (backwards or forwards)
            speed = rigidBody.velocity.magnitude; //speed to be called from speedometer manager

            //Y axis controls rotation
            mesh.transform.Rotate(0f, magnitude * direction / circumference, 0f);
        }
    }
}

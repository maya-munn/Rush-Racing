using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class Drive : MonoBehaviour
    {
        //public float m_horizontalInput;
        //public float m_verticalInput;
        //private float m_steeringAngle;

        //public WheelCollider frontDriverW, frontPassengerW;
        //public WheelCollider rearDriverW, rearPassengerW;
        //public Transform frontDriverT, frontPassengerT;
        //public Transform rearDriverT, rearPassengerT;
        //public float maxSteerAngle = 30;
        //public float motorForce = 50;

        //public void GetInput()
        //{
        //    m_horizontalInput = Input.acceleration.x;
        //    m_verticalInput = CrossPlatformInputManager.GetAxis("Vertical");
        //}

        //private void Steer()
        //{
        //    m_steeringAngle = maxSteerAngle * m_horizontalInput;
        //    frontDriverW.steerAngle = m_steeringAngle;
        //    frontPassengerW.steerAngle = m_steeringAngle;


        //}

        //private void Accelerate()
        //{
        //    frontDriverW.motorTorque = m_verticalInput * motorForce;
        //    frontPassengerW.motorTorque = m_verticalInput * motorForce;
        //}

        //private void UpdateWheelPoses()
        //{
        //    UpdateWheelPose(frontDriverW, frontDriverT);
        //    UpdateWheelPose(frontPassengerW, frontPassengerT);
        //    UpdateWheelPose(rearDriverW, rearDriverT);
        //    UpdateWheelPose(rearPassengerW, rearPassengerT);
        //}

        //private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
        //{
        //    Vector3 _pos = _transform.position;
        //    Quaternion _quat = _transform.rotation;

        //    _collider.GetWorldPose(out _pos, out _quat);


        //    _transform.rotation = _quat;
        //    _transform.position = _pos;

        //}


        //private void FixedUpdate()
        //{
        //    GetInput();
        //    Steer();
        //    Accelerate();
        //    UpdateWheelPoses();
        //}

        public float speed = 10.0f;
        public float rotationSpeed = 100.0F;



        public void Update()
        {
            float translation = CrossPlatformInputManager.GetAxis("Vertical") * speed;
            float rotation = CrossPlatformInputManager.GetAxis("Horizontal") * rotationSpeed;
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);


        }

    }
}

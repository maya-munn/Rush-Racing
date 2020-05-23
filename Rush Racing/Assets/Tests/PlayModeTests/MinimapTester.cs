using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Audio;
using UnityEngine.TestTools;
using UnityEngine.UI;
/*  <summary>
A testing script with unit tests to check if minimap feature is working properly.
Author: Bernadette Cruz
*/
namespace Tests
{
    public class MinimapTester
    {   
        public GameObject CarTarget;
        public GameObject MinimapCamera;
 

        [SetUp]
        public void Setup()
        {
            CarTarget = GameObject.Instantiate(new GameObject());
            MinimapCamera = GameObject.Instantiate(new GameObject());
   
        }

        [Test]
        public void Check_Car_Exists()
        {
            Assert.NotNull(CarTarget);
        }

        [Test]
        public void Check_MinimapCamera_Exists()
        {
            Assert.NotNull(MinimapCamera);
        }


        [UnityTest]
        public IEnumerator Camera_Following_Car()
        {   
            //Initial position of Car
            float carX = CarTarget.transform.position.x;
            float carY = CarTarget.transform.position.y;
            float carZ = CarTarget.transform.position.z;

            CarTarget.transform.position = new UnityEngine.Vector3(carX + UnityEngine.Random.Range(0, 100), carY + UnityEngine.Random.Range(0, 100),
                carZ + UnityEngine.Random.Range(0, 100)); //simulates a car moving

            //The car's new position after being updated
            float newX = CarTarget.transform.position.x;
            float newY = CarTarget.transform.position.y;
            float newZ = CarTarget.transform.position.z;

            //updates camera's position to car, but adds a fixed value to Y position so that camera is above the car.
            MinimapCamera.transform.position = new UnityEngine.Vector3(newX, newY + 40, newZ);
            
         
            float camX = MinimapCamera.transform.position.x;
            float camY = MinimapCamera.transform.position.y;
            float camZ = MinimapCamera.transform.position.z;

            //checks if camera position is equal to car position (with the exception of Y -- to show that camera is following car from above)
            Assert.AreEqual((newX, newZ), (camX, camZ));
            yield return new WaitForSeconds(0.1f);
        }


    }
}

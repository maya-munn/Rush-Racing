using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Audio;
using UnityEngine.TestTools;
using UnityEngine.UI;
/*  <summary>
A testing script with unit tests to check if volume feature is working properly.
Author: Bernadette Cruz
*/
namespace Tests
{
    public class VolumeTester
    {   
        public GameObject CarTarget;
 

        [SetUp]
        public void Setup()
        {
            //CarTarget = GameObject.Instantiate(new GameObject());
   
        }

        public void Check_Car_Exists()
        {
            Assert.NotNull(CarTarget);
        }
            



        //[UnityTest]
        //public IEnumerator tester()
        //{
            
        //    yield return null;
        //}

        
    }
}

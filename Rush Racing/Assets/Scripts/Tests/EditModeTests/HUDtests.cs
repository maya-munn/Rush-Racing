using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HUDtests : MonoBehaviour
    {
        //This will create an object from the scripts involved,
        public LapComplete lapC;
        public LapTimeManager ltMgr;

        [SetUp]
        public void SetUp(){
            lapC = new LapComplete();
        }

        [Test]
        public void LapsDoneIncrementation(){
            //Will whether or not the laps done by the player will increment by one each time they pass through the lap trigger.
            int testLapsDone = 0;
            int scriptLapsDone = lapC.LapsDone;
            lapC.LapIncrementer();

            testLapsDone++;
            Assert.AreEqual(testLapsDone, scriptLapsDone);
        }

    }
}

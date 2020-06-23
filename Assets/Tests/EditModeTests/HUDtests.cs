using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HUDtests
    {
        //This will create an object from the scripts involved,
        public LapComplete lapC;
        public LapTimeManager ltMgr;

        [SetUp]
        public void SetUp(){
            lapC = new LapComplete();
            ltMgr = new LapTimeManager();
        }

        [Test]
        public void LapsDoneIncrementation(){
            //Will whether or not the laps done by the player will increment by one each time they pass through the lap trigger.
            int testLapsDone = 0;
            int scriptLapsDone = lapC.LapsDone;

           // lapC.OnTriggerEnter();

            testLapsDone++;
            Assert.AreEqual(testLapsDone, scriptLapsDone);
        }

        
        [Test]
        public IEnumerator LapTimerStart(){
            //Will call the Update method on the object instnce of LapTimeManager, which allows it to start the timer.
            int scriptSeconds = ltMgr.SecondCountTesting;

            ltMgr.Update();

            yield return new WaitForSeconds(5);

            if(scriptSeconds >= 5){
                Assert.Pass("Passed test!");
            }else{
                Assert.Fail("Did not pass test!");
            }
        }

        [Test]
        public void RaceFinishTriggerTest(){
            //Will test if the laps will activate the state 'RaceFinish' to active which will activate the race finish trigger.
            int scriptLapsForFinish = 0;
            bool rFinish = false;

            if(scriptLapsForFinish >= 4){
                rFinish = true;
            }

            scriptLapsForFinish += 5;

            if(rFinish == true){
                Assert.Pass("Passed Test!");
            }else{
                Assert.Fail("Did not pass test!");
            }
        }
    }
}

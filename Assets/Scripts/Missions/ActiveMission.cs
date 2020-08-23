using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Definitions.Missions {

    public class ActiveMission: MonoBehaviour {

        //mission details for regarding this active mission
        public MissionDetails missionDetails;

        //time in utc that the mission will complete
        public DateTime completionTime;

        //text displaying time remaining
        private Text timeRemainingText;

        public void initialise(MissionDetails missionDetails, DateTime completionTime) {
            this.missionDetails = missionDetails;
            this.completionTime = completionTime;
            timeRemainingText = this.transform.Find("MissionTime").GetComponent<Text>();
        }

        IEnumerator missionCountdown() {
            //calculate time remaining from completion time to now
            float remainingTime = (float)(this.completionTime - DateTime.UtcNow).TotalSeconds;
            Debug.Log("RT: " + remainingTime);

            //while the mission has not completed
            while (remainingTime > 0) {
                //reduce time remaining by time passed since last update
                remainingTime -= Time.deltaTime;

                //set up the display for the remaining time on the panel
                string missionTime = "Remaining Time: ";
                if(remainingTime >= 60) {
                    TimeSpan time = TimeSpan.FromSeconds(remainingTime);
                    missionTime += time.Days > 0 ? time.Days + "d " + time.Hours + "h " : time.Hours > 0 ? time.Hours + "h " : "";
                    missionTime += time.Minutes + "m ";
                } else {
                    missionTime += (int)remainingTime + "s";
                }

                //set the remaining time text on the panel
                timeRemainingText.text = missionTime;

                yield return null;
            }
        }

        public void startMission() {
            StartCoroutine(missionCountdown());
        }

        public override string ToString() {
            return "Mission Details: {" + this.missionDetails.ToString() + "}, Completion Time: " + this.completionTime.ToString(@"M/d/yyyy hh:mm:ss tt");
        }
    }
}
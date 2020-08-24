using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using Definitions.Missions;

namespace Missions {
    [System.Serializable]

    public class ActiveMission: MonoBehaviour {

        //mission details for regarding this active mission
        public ActiveMissionDetails activeMissionDetails;

        //text displaying time remaining
        private Text timeRemainingText;

        //the button used to selet the panel
        private Button selectButton;

        public void initialise(ActiveMissionDetails activeMissionDetails) {
            this.activeMissionDetails = activeMissionDetails;
            timeRemainingText = this.transform.Find("TimeRemaining").GetComponent<Text>();
            selectButton = this.transform.Find("SelectButton").GetComponent<Button>();
        }

        IEnumerator missionCountdown() {
            //calculate time remaining from completion time to now
            float remainingTime = (float)(this.activeMissionDetails.completionTime - DateTime.UtcNow).TotalSeconds;

            //while the mission has not completed
            while (remainingTime > 0) {
                //reduce time remaining by time passed since last update
                remainingTime -= Time.deltaTime;

                //set up the display for the remaining time on the panel
                string missionTime = "Remaining Time: ";
                if(remainingTime >= 60) {
                    TimeSpan time = TimeSpan.FromSeconds(remainingTime);
                    missionTime += time.Days > 0 ? (time.Days + "d " + time.Hours + "h ") : (time.Hours > 0 ? time.Hours + "h " : "");
                    missionTime += time.Minutes + "m ";
                } else {
                    missionTime += (int)remainingTime + "s";
                }

                //set the remaining time text on the panel
                timeRemainingText.text = missionTime;

                yield return null;
            }
            
            //set the remaining time text on the panel
            timeRemainingText.text = "Mission Complete";

            //allow the panel to be selectable
            selectButton.interactable = true;
        }

        public void continueMission() {
            StartCoroutine(missionCountdown());
        }
    }
}
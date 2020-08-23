using Definitions.Missions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menus {
    public class ActiveMissionView : MonoBehaviour {

        private ActiveMission[] activeMissions;

        void Start() {
            activeMissions = GetComponentsInChildren<ActiveMission>();
        }

        void OnEnable() {
            activeMissions = GetComponentsInChildren<ActiveMission>();

            foreach(ActiveMission mission in activeMissions) {
                mission.continueMission();
            }
        }
    }
}
using System;

namespace Definitions.Missions {
    [System.Serializable]

    public class ActiveMissionDetails {

        //mission details for regarding this active mission
        public MissionDetails missionDetails;

        //time in utc that the mission will complete
        public DateTime completionTime;

        public ActiveMissionDetails(MissionDetails missionDetails, DateTime completionTime) {
            this.missionDetails = missionDetails;
            this.completionTime = completionTime;
        }

        public override string ToString() {
            return "Mission Details: {" + this.missionDetails.ToString() + "}, Completion Time: " + this.completionTime.ToString(@"d/M/yyyy hh:mm:ss tt");
        }
    }
}
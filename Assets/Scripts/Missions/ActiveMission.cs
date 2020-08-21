namespace Definitions.Missions {

    public class ActiveMission {

        //mission detailsfor regarding this active mission
        public MissionDetails missionDetails;

        //time in utc that the mission will complete
        public System.DateTime completionTime;

        public ActiveMission(MissionDetails missionDetails, System.DateTime completionTime) {
            this.missionDetails = missionDetails;
            this.completionTime = completionTime;
        }

        public override string ToString() {
            return "Mission Details: {" + this.missionDetails.ToString() + "}, Completion Time: " + this.completionTime.ToString(@"M/d/yyyy hh:mm:ss tt");
        }
    }
}
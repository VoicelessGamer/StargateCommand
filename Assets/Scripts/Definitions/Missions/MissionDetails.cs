namespace Definitions.Missions {

    public class MissionDetails {

        //mission definition details
        public MissionDefinition missionDefinition;

        //mission time in seconds
        public long missionTime;

        //chance of passing this mission as percentage decimal
        public float passRate;

        public MissionDetails(MissionDefinition missionDefinition, long missionTime, float passRate) {
            this.missionDefinition = missionDefinition;
            this.missionTime = missionTime;
            this.passRate = passRate;
        }

        public override string ToString() {
            return "Mission Definition: {" + this.missionDefinition.ToString() + "}, Mission Time: " + this.missionTime + ", Pass Rate: " + this.passRate;
        }
    }
}
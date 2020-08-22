using Definitions.Destinations;

namespace Definitions.Missions {

    public class MissionDetails {

        //mission definition details
        public MissionDefinition missionDefinition;

        //details regarding the destination of the mission
        public DestinationDetails destinationDetails;

        //mission time in seconds
        public long missionTime;

        //chance of passing this mission as percentage decimal
        public float passRate;

        public MissionDetails(MissionDefinition missionDefinition, DestinationDetails destinationDetails, long missionTime, float passRate) {
            this.missionDefinition = missionDefinition;
            this.destinationDetails = destinationDetails;
            this.missionTime = missionTime;
            this.passRate = passRate;
        }

        public override string ToString() {
            return "Mission Definition: {" + this.missionDefinition.ToString() + "}, Destination Details: {" + this.destinationDetails.ToString() + "}, Mission Time: " + this.missionTime + ", Pass Rate: " + this.passRate;
        }
    }
}
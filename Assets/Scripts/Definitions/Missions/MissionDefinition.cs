namespace Definitions.Missions {

    public class MissionDefinition {

        public enum MissionType {
            EXPLORATION,
            RECON,
            ASSAULT,
            DEFENCE,
            NEGOTIATION,
            CAPTURE,
            EXTRACTION,
            RESEARCH
        }

        public MissionType missionType;

        //mission time in seconds
        public long baseMissionTime;

        //pass chance between 0 and 1
        public float basePassRate;

        public override string ToString() {
            return "Base Mission Time: " + this.baseMissionTime + ", Base Pass Rate: " + this.basePassRate;
        }
    }
}
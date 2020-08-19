namespace Definitions.Missions {

    public class MissionDefinition {

        //mission time in seconds
        public long baseMissionTime;

        //pass chance between 0 and 1
        public float basePassRate;

        public override string ToString() {
            return "Base Mission Time: " + this.baseMissionTime + ", Base Pass Rate: " + this.basePassRate;
        }
    }
}
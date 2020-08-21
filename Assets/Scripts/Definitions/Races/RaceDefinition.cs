namespace Definitions.Races {

    public class RaceDefinition {

        //number representing this race' technology level which can be used in difficulty calculations
        public int technologyLevel;

        //list of threshold which determine the player' friendship level with this race
        public int[] friendshipThresholds;

        public override string ToString() {
            string str = "Technology Level: " + this.technologyLevel + ", Friendship: [";
            for(int i = 0; i < friendshipThresholds.Length; i++) {
                str += friendshipThresholds[i];
                if(i < friendshipThresholds.Length - 1) {
                    str += ", ";
                }
            }
            return str + "]";
        }
    }
}
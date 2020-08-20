namespace Definitions.Races {

    public class RaceDefinition {

        //whether this race is initially hostile to the player
        public bool hostile;

        //
        //public int technologyLevel;

        //
        //public friendshipThresholds;

        public override string ToString() {
            return "Hostile: " + this.hostile;
        }
    }
}
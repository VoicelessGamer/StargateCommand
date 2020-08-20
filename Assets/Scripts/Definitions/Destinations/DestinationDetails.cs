using Definitions.Races;

namespace Definitions.Destinations {
    [System.Serializable]
    public class DestinationDetails {

        public RaceDefinitions.Race? occupyingRace;

        public DestinationDefinition destinationDefinition;

        public DestinationDetails(DestinationDefinition destinationDefinition) {
            this.destinationDefinition = destinationDefinition;
            this.occupyingRace = null;
        }

        public DestinationDetails(DestinationDefinition destinationDefinition, RaceDefinitions.Race occupyingRace) {
            this.destinationDefinition = destinationDefinition;
            this.occupyingRace = occupyingRace;
        }

        public override string ToString() {
            return "Occupying Race: " + this.occupyingRace + ", Destination Definition: { " + this.destinationDefinition.ToString() + "}";
        }
    }
}
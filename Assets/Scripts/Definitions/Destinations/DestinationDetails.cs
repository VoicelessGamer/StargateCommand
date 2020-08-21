using Definitions.Races;

namespace Definitions.Destinations {
    [System.Serializable]
    public class DestinationDetails {

        public RaceDefinitions.Race governingRace;

        public DestinationDefinition destinationDefinition;

        public DestinationDetails(DestinationDefinition destinationDefinition, RaceDefinitions.Race governingRace) {
            this.destinationDefinition = destinationDefinition;
            this.governingRace = governingRace;
        }

        public override string ToString() {
            return "Governing Race: " + this.governingRace + ", Destination Definition: { " + this.destinationDefinition.ToString() + "}";
        }
    }
}
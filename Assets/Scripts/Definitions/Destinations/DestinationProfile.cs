using Definitions.Races;
using Core;

namespace Definitions.Destinations {
    [System.Serializable]
    public class DestinationProfile {
        //weighted chance of a newly created destinations environmental state
        public WeightedEnvironmentState[] environmentStateWeights;

        //chances of a newly created destination having an occupying race
        public WeightedBool[] occupyingRaceWeights;

        //weighted chance of a newly created destinations occupying race
        public WeightedRace[] raceWeights;
    }
}
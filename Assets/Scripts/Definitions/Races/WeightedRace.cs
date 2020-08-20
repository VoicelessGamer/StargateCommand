using Core;

namespace Definitions.Races {
    [System.Serializable]
    public class WeightedRace : WeightedValue {
        public RaceDefinitions.Race value { get; set; }
        
        public long weight { get; set; }

        public long getWeight() {
            return this.weight;
        }
    }
}

using Core;

namespace Definitions.Destinations {
    [System.Serializable]
    public class WeightedEnvironmentState : WeightedValue {
        public DestinationDefinition.EnvironmentState value { get; set; }
        
        public long weight { get; set; }

        public long getWeight() {
            return this.weight;
        }
    }
}

using Core;

namespace Definitions.Items {
    [System.Serializable]
    public class WeightedWeaponDefinition : WeightedValue {
        public WeaponDefinition value { get; set; }
        
        public long weight { get; set; }

        public long getWeight() {
            return this.weight;
        }
    }
}

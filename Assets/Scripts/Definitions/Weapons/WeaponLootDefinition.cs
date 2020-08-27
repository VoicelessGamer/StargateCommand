using Core;

namespace Definitions.Weapons {
    [System.Serializable]
    public class WeaponLootDefinition: WeightedValue {

        //name of the weapon id
        public string name;

        //weighted chances of selecting given rarity
        public WeightedRarityObject[] rarityWeights;

        public long weight;

        public long getWeight() {
            return weight;
        }
    }
}
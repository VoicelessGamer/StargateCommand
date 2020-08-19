using Core;
using Definitions.Items;
using System.Collections.Generic;

namespace Definitions.Enemies {
    [System.Serializable]
    public class EnemyDefinition {

        //number of drops that could be received from this enemy type
        public int lootDrops;

        //array of the loot drop types such as ballistic_main_weapons or energy_main_weapons etc. weighted by chance of selection
        public WeightedString[] lootDropTypeWeights;

        //array of the loot drop groups, for each option in the lootDropTypeWeights array, 
        //such as assault_rifles or random etc. weighted by chance of selection
        public Dictionary<string, WeightedString[]> lootDropGroupWeights;

        //weighted rarities of loot items for this enemy type
        public WeightedRarityObject[] rarityWeights;
    }
}
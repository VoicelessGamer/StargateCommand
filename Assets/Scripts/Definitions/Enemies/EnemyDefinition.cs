using Core;
using Definitions.Items;
using System.Collections.Generic;

namespace Definitions.Enemies {
    [System.Serializable]
    public class EnemyDefinition {

        public int lootDrops;

        public WeightedString[] lootDropTypeWeights;

        public Dictionary<string, WeightedString[]> lootDropGroupWeights;

        public WeightedRarityObject[] rarityWeights;
    }
}
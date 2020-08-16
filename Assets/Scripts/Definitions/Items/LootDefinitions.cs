using System.Collections.Generic;

namespace Definitions.Items {
    [System.Serializable]
    public class LootDefinitions {

        public Dictionary<string, Dictionary<string, Dictionary<RarityObject.Rarity, WeightedWeaponDefinition[]>>> weaponDefinitions;
    }
}
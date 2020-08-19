using System.Collections.Generic;

namespace Definitions.Items {
    [System.Serializable]
    public class LootDefinitions {

        //key = loot type such as ballistic_main_weapons
        //value =>
        //  key = loot type group such as assault_rifles
        //  value =>
        //      key = rarity type
        //      value = list of weapon definitions weighted by chance of selection
        public Dictionary<string, Dictionary<string, Dictionary<RarityObject.Rarity, WeightedWeaponDefinition[]>>> weaponDefinitions;
    }
}
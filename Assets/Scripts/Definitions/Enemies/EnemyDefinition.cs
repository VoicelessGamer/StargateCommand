using Core;
using Definitions.Weapons;

namespace Definitions.Enemies {
    [System.Serializable]
    public class EnemyDefinition {

        //number of drops that could be received from this enemy type
        public int lootDrops;

        //array of the loot drop types such as weapon or resource etc. weighted by chance of selection
        public WeightedString[] lootDropTypes;

        //array of weapon loot definitions containing the information on a weapon id and rarity drop chances
        public WeaponLootDefinition[] weaponWeights;
    }
}
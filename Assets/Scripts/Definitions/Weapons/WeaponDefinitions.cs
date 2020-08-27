using System.Collections.Generic;
using Core;

namespace Definitions.Weapons {
    [System.Serializable]
    public class WeaponDefinitions {

        //key = weapon name such as M16A3
        //value =>
        //  key = rarity type such as COMMON
        //  value = weapon definition
        public Dictionary<string, Dictionary<RarityObject.Rarity, WeaponDefinition>> definitions;
    }
}
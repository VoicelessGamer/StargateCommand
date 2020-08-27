using UnityEngine;
using Newtonsoft.Json;
using Definitions.Weapons;
using Core;

namespace Weapons {
    public static class WeaponUtil {
        private static string weaponDefinitionPath = "Json/WeaponDefinitions";

        public static WeaponDefinition getWeapon(string weapon, RarityObject.Rarity rarity) {

            //load the weapon definitions into a text asset
            TextAsset weaponDefinitionJson = Resources.Load<TextAsset>(weaponDefinitionPath);

            //deserialize the weapon definitions into an object
            WeaponDefinitions weaponDefinitions = JsonConvert.DeserializeObject<WeaponDefinitions>(weaponDefinitionJson.text);

            return weaponDefinitions.definitions[weapon][rarity];
        }
    }
}
using UnityEngine;
using Weapons;
using Definitions.Enemies;
using Core;
using Newtonsoft.Json;
using Definitions.Weapons;

namespace Generation {
    public class RandomLootGenerator {

        private static string enemyDefinitionPath = "Json/EnemyDefinitions";

        private EnemyDefinitions enemyDefinitions;

        public RandomLootGenerator() {
            //load the enemy definitions into a text asset
            TextAsset enemyDefinitionJson = Resources.Load<TextAsset>(enemyDefinitionPath);

            //deserialize the enemy definitions into an object
            enemyDefinitions = JsonConvert.DeserializeObject<EnemyDefinitions>(enemyDefinitionJson.text);
        }

        //temporarily returning weapon list. Need to fix when implementing other drop types
        public WeaponDefinition[] generateLoot(string enemyId) {

            //check the enemy id matches a key in the enemy definitions
            if(!enemyDefinitions.definitions.ContainsKey(enemyId)) {
                throw new System.Exception("Missing enemy id.");
            }
            
            //retrieve the enemy details
            EnemyDefinition definition = enemyDefinitions.definitions[enemyId];

            //create an array to store the loot drops
            WeaponDefinition[] generatedDefinitions = new WeaponDefinition[definition.lootDrops];

            for (int i = 0; i < definition.lootDrops; i++) {
                //randomly select the loot drop type such as weapon, armour, resource etc.
                string dropType = ((WeightedString)WeightedValueSelector.selectValue(definition.lootDropTypes)).value;

                switch(dropType) {
                    case "WEAPON":
                        //using the selected loot drop type, randomly select the inner group of loot items such as assault_rifles
                        WeaponLootDefinition weaponLootDefinition = ((WeaponLootDefinition)WeightedValueSelector.selectValue(definition.weaponWeights));

                        //randomly select the rarity type of the loot drop
                        RarityObject.Rarity rarity = ((WeightedRarityObject)WeightedValueSelector.selectValue(weaponLootDefinition.rarityWeights)).value;

                        //using the randomly selected information retrieve a weapon definition and add to loot list
                        generatedDefinitions[i] = WeaponUtil.getWeapon(weaponLootDefinition.name, rarity);
                        break;
                    case "ARMOUR":
                        break;
                    case "INTEL":
                        break;
                    case "RESOURCE":
                        break;
                    case "NONE":
                        break;
                }

            }

            //return the list of awarded loot types
            return generatedDefinitions;
        }
    }
}
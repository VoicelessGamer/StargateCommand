using UnityEngine;
using Definitions.Items;
using Definitions.Enemies;
using Core;
using Newtonsoft.Json;

namespace Generation {
    public class RandomLootGenerator {

        private static string itemDefinitionPath = "Json/LootDefinitions";
        private static string enemyDefinitionPath = "Json/EnemyDefinitions";

        private static System.Random random;

        private LootDefinitions lootDefinitions;

        private EnemyDefinitions enemyDefinitions;

        public RandomLootGenerator() {
            random = new System.Random();

            //load the loot definitions into a text asset
            TextAsset lootDefinitionJson = Resources.Load<TextAsset>(itemDefinitionPath);

            //deserialize the loot definitions into an object
            lootDefinitions = JsonConvert.DeserializeObject<LootDefinitions>(lootDefinitionJson.text);

            //load the enemy definitions into a text asset
            TextAsset enemyDefinitionJson = Resources.Load<TextAsset>(enemyDefinitionPath);

            //deserialize the enemy definitions into an object
            enemyDefinitions = JsonConvert.DeserializeObject<EnemyDefinitions>(enemyDefinitionJson.text);
        }

        public ItemDefinition[] generateLoot(string enemyId) {

            //check the enemy id matches a key in the enemy definitions
            if(!enemyDefinitions.definitions.ContainsKey(enemyId)) {
                throw new System.Exception("Missing enemy id.");
            }
            
            //retrieve the enemy details
            EnemyDefinition definition = enemyDefinitions.definitions[enemyId];

            //create an array to store the loot drops
            ItemDefinition[] generatedDefinitions = new ItemDefinition[definition.lootDrops];

            for (int i = 0; i < definition.lootDrops; i++) {
                //randomly select the loot drop type such as ballistic_main_weapons
                string dropType = ((WeightedString)WeightedValueSelector.selectValue(definition.lootDropTypeWeights)).value;

                //using the selected loot drop type, randomly select the inner group of loot items such as assault_rifles
                string dropTypeGroup = ((WeightedString)WeightedValueSelector.selectValue(definition.lootDropGroupWeights[dropType])).value;

                //randomly select the rarity type of the loot drop
                RarityObject.Rarity rarity = ((WeightedRarityObject)WeightedValueSelector.selectValue(definition.rarityWeights)).value;

                //using the randomly selected keys retrieve a weapon definition
                WeaponDefinition itemDef = getWeaponItem(dropType, dropTypeGroup, rarity);

                //add the loot to the loot drop list
                generatedDefinitions[i] = itemDef;
            }

            //return the list of awarded loot types
            return generatedDefinitions;
        }

        public WeaponDefinition getWeaponItem(string dropType, string dropTypeGroup, RarityObject.Rarity rarity) {
            return ((WeightedWeaponDefinition)WeightedValueSelector.selectValue(lootDefinitions.weaponDefinitions[dropType][dropTypeGroup][rarity])).value;
        }
    }
}
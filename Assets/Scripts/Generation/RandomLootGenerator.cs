using UnityEngine;
using Definitions.Items;
using Definitions.Enemies;
using Core;
using Newtonsoft.Json;

namespace Items.ItemGeneration {
    public class RandomLootGenerator {

        private static string itemDefinitionPath = "Json/LootDefinitions";
        private static string enemyDefinitionPath = "Json/EnemyDefinitions";

        private static System.Random random;

        private LootDefinitions lootDefinitions;

        private EnemyDefinitions enemyDefinitions;

        public RandomLootGenerator() {
            random = new System.Random();

            TextAsset lootDefinitionJson = Resources.Load<TextAsset>(itemDefinitionPath);

            lootDefinitions = JsonConvert.DeserializeObject<LootDefinitions>(lootDefinitionJson.text);

            TextAsset enemyDefinitionJson = Resources.Load<TextAsset>(enemyDefinitionPath);

            enemyDefinitions = JsonConvert.DeserializeObject<EnemyDefinitions>(enemyDefinitionJson.text);
        }

        public ItemDefinition[] generateLoot(string enemyId) {

            if(!enemyDefinitions.definitions.ContainsKey(enemyId)) {
                throw new System.Exception("Missing enemy id.");
            }
            
            EnemyDefinition definition = enemyDefinitions.definitions[enemyId];

            ItemDefinition[] generatedDefinitions = new ItemDefinition[definition.lootDrops];

            for (int i = 0; i < definition.lootDrops; i++) {

                string dropType = ((WeightedString)WeightedValueSelector.selectValue(definition.lootDropTypeWeights)).value;

                string dropTypeGroup = ((WeightedString)WeightedValueSelector.selectValue(definition.lootDropGroupWeights[dropType])).value;

                RarityObject.Rarity rarity = ((WeightedRarityObject)WeightedValueSelector.selectValue(definition.rarityWeights)).value;

                WeaponDefinition itemDef = ((WeightedWeaponDefinition)WeightedValueSelector.selectValue(lootDefinitions.weaponDefinitions[dropType][dropTypeGroup][rarity])).value;

                generatedDefinitions[i] = itemDef;
            }

            return generatedDefinitions;
        }


        /*private Weapon generateRandomWeapon(ItemDefinition weaponDefinition) {
            return new Weapon(weaponDefinition.name, random.NextDouble() * (weaponDefinition.maximumDamage - weaponDefinition.minimumDamage) + weaponDefinition.minimumDamage, weaponDefinition);
        }*/
    }
}
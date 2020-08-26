using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using Generation;
using Definitions.Items;

namespace Assets.Scripts.Testing {
    class ItemGenerationTestClass: MonoBehaviour {

        private int totalTests = 1000000;

        void Start() {

            testEnemyLoot();
            //testSerialization();
        }

        public void testSerialization() {

            Dictionary<RarityObject.Rarity, WeaponDefinition> dict = new Dictionary<RarityObject.Rarity, WeaponDefinition>();

            WeaponDefinition wd = new WeaponDefinition();

            wd.name = "test";
            wd.minimumDamage = 1.1f;
            wd.maximumDamage = 3.4f;
            wd.damageType = WeaponDefinition.DamageType.BALLISTIC;
            wd.rarity = RarityObject.Rarity.RARE;

            dict.Add(RarityObject.Rarity.LEGENDARY, wd);

            string json = JsonConvert.SerializeObject(dict, Formatting.Indented);

            Debug.Log(json);

            Dictionary<RarityObject.Rarity, WeaponDefinition> dict2 = new Dictionary<RarityObject.Rarity, WeaponDefinition>();

            dict2 = JsonConvert.DeserializeObject<Dictionary<RarityObject.Rarity, WeaponDefinition>>(json);

        }

        public void testEnemyLoot() {
            Dictionary<RarityObject.Rarity, int> rarities = new Dictionary<RarityObject.Rarity, int>();
            Dictionary<WeaponDefinition.WeaponType, int> wt = new Dictionary<WeaponDefinition.WeaponType, int>();
            Dictionary<WeaponDefinition.DamageType, int> dt = new Dictionary<WeaponDefinition.DamageType, int>();

            RandomLootGenerator rig = new RandomLootGenerator();

            for (int i = 0; i < totalTests; i++) {
                ItemDefinition[] generatedItems = rig.generateLoot("jaffa");

                for (int j = 0; j < generatedItems.Length; j++) {
                    WeaponDefinition w = (WeaponDefinition)generatedItems[j];

                    if(!rarities.ContainsKey(w.rarity)) {
                        rarities.Add(w.rarity, 1);
                    } else {
                        rarities[w.rarity] = rarities[w.rarity] + 1;
                    }


                    if (!wt.ContainsKey(w.weaponType)) {
                        wt.Add(w.weaponType, 1);
                    } else {
                        wt[w.weaponType] = wt[w.weaponType] + 1;
                    }


                    if (!dt.ContainsKey(w.damageType)) {
                        dt.Add(w.damageType, 1);
                    } else {
                        dt[w.damageType] = dt[w.damageType] + 1;
                    }

                    //Debug.Log(w.ToString());
                }
            }

            foreach (RarityObject.Rarity key in rarities.Keys) {
                Debug.Log("Key: " + key + ", Value: " + rarities[key]);
            }

            foreach (WeaponDefinition.WeaponType key in wt.Keys) {
                Debug.Log("Key: " + key + ", Value: " + wt[key]);
            }

            foreach (WeaponDefinition.DamageType key in dt.Keys) {
                Debug.Log("Key: " + key + ", Value: " + dt[key]);
            }
        }
    }
}

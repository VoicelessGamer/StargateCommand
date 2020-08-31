using UnityEngine;
using Newtonsoft.Json;
using Definitions.Items;
using System.IO;
using System.Collections.Generic;
using Core;

namespace Items {
    public static class ItemUtil {
        private static string inventoryPath = "/Inventory.json";

        public static Color getRarityColour(RarityObject.Rarity rarity) {
            switch (rarity) {
                case RarityObject.Rarity.LEGENDARY:
                    //orange
                    return new Color(0.941f, 0.553f, 0f);
                case RarityObject.Rarity.VERY_RARE:
                    //purple
                    return new Color(0.569f, 0.196f, 0.784f);
                case RarityObject.Rarity.RARE:
                    //blue
                    return new Color(0.184f, 0.47f, 1f);
                case RarityObject.Rarity.UNCOMMON:
                    //green
                    return new Color(0.235f, 0.816f, 0.0143f);
                case RarityObject.Rarity.COMMON:
                default:
                    //grey
                    return new Color(0.314f, 0.314f, 0.314f);
            }
        }

        public static Inventory getInventory() {
            Inventory inventory;

            //check the persistent data folder for the Inventory json
            if (!File.Exists(Application.persistentDataPath + inventoryPath)) {
                //file does not exist

                //create a new Inventory object
                inventory = new Inventory();

                saveInventory(inventory);
            } else {
                //file exists, load text into a string
                string storedString = File.ReadAllText(Application.persistentDataPath + inventoryPath);

                //deserialize and return the string into an Inventory object
                inventory = JsonConvert.DeserializeObject<Inventory>(storedString);
            }

            return inventory;
        }

        public static void saveInventory(Inventory inventory) {

            //serialize the Inventory object to a string
            string inventoryJson = JsonConvert.SerializeObject(inventory, Formatting.None);

            //write string to a new json file in the persistent data folder
            File.WriteAllText(Application.persistentDataPath + inventoryPath, inventoryJson);
        }
    }
}
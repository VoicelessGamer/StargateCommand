using UnityEngine;
using Newtonsoft.Json;
using Definitions.Items;
using System.IO;

namespace Items {
    public static class ItemUtil {
        private static string inventoryPath = "/Inventory.json";

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
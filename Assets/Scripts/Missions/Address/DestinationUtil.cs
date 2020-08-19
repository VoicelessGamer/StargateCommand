using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Definitions.Destinations;

namespace Missions.Address {
    public static class DestinationUtil {
        private static string knownAddressFilePath = "/KnownAddressData.json";

        //array of all the characters that can be used in creating a random planet designation
        private static string[] designationCharacters = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public static DestinationDefinition getDestinationData(int[] address) {
            Destinations destinations;
            DestinationDefinition destinationDefinition;

            //check the persistent data folder for the known address json
            if (!File.Exists(Application.persistentDataPath + knownAddressFilePath)) {
                //file does not exist

                //create a new destinations object
                destinations = new Destinations();

                //generate a new set of destination details for the given address
                destinationDefinition = generateDestinationDefinition(address);

                //store the newly generated details under a string converted address key in the new destinations object
                destinations.addDestinationData(convertAddressToStringKey(address), destinationDefinition);

                //serialize the destinations object to a string
                string destinationJson = JsonConvert.SerializeObject(destinations, Formatting.None);

                //write string to a new json file in the persistent data folder
                File.WriteAllText(Application.persistentDataPath + knownAddressFilePath, destinationJson);

                //return the new details
                return destinationDefinition;
            }

            //file exists, load text into a string
            string storedString = File.ReadAllText(Application.persistentDataPath + knownAddressFilePath);
            
            //deserialize the string into a destinations object
            destinations = JsonConvert.DeserializeObject<Destinations>(storedString);

            //using a string converted address key get the destination details
            destinationDefinition = destinations.getDestinationData(convertAddressToStringKey(address));

            //if the data returned is null generate new details
            if (destinationDefinition == null) {
                //generate a new set of destination details for the given address
                destinationDefinition = generateDestinationDefinition(address);

                //store the newly generated details under a string converted address key in the new destinations object
                destinations.addDestinationData(convertAddressToStringKey(address), destinationDefinition);

                //serialize the destinations object to a string
                string destinationJson = JsonConvert.SerializeObject(destinations, Formatting.None);

                //write string to a new json file in the persistent data folder
                File.WriteAllText(Application.persistentDataPath + knownAddressFilePath, destinationJson);
            }

            return destinationDefinition;
        }

        private static DestinationDefinition generateDestinationDefinition(int[] address) {
            return new DestinationDefinition(generateRandomDesignation(), address);
        }

        private static string generateRandomDesignation() {
            string designation = "P";

            System.Random random = new System.Random();

            //generates 2 random characters
            for (int i = 0; i < 2; i++) {
                designation += designationCharacters[random.Next(0, designationCharacters.Length)];
            }

            //adds hyphon separator
            designation += "-";

            //generates 3 random characters
            for (int i = 0; i < 3; i++) {
                designation += designationCharacters[random.Next(0, designationCharacters.Length)];
            }

            return designation;
        }

        public static string convertAddressToStringKey(int[] address) {
            string key = "";

            //convert the given address to a string with each index separated by a hyphon
            for (int i = 0; i < address.Length - 1; i++) {
                key += address[i] + "-";
            }

            //add last index to string
            key += address[address.Length - 1];

            return key;
        }

        public static int[] generateRandomAddress(int addressSize) {
            //all available symbol index (excludes point of origin)
            List<int> availableSymbols = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38 };

            //setup the address array with given size
            int[] address = new int[addressSize];

            System.Random random = new System.Random();

            for (int i = 1; i < addressSize; i++) {
                //randomly select an index within the availableSymbols array
                int index = random.Next(0, availableSymbols.Count);

                //add symbol index to the address
                address[i - 1] = availableSymbols[index];

                //remove index from available symbols so cannot be re-selected
                availableSymbols.RemoveAt(index);
            }

            //add point of origin to end of address
            address[address.Length - 1] = 0;

            return address;
        }
    }
}
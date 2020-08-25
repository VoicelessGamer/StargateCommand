using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Definitions.Destinations;
using Definitions.Races;
using Core;

namespace Missions.Address {
    public static class DestinationUtil {
        private static string knownAddressFilePath = "/KnownAddressData.json";

        private static string destinationsProfileFilePath = "Json/DestinationProfile";

        //array of all the characters that can be used in creating a random planet designation
        private static WeightedString[] designationCharacters = new WeightedString[] {
            new WeightedString("0", 30),
            new WeightedString("1", 78),
            new WeightedString("2", 102),
            new WeightedString("3", 201),
            new WeightedString("4", 105),
            new WeightedString("5", 90),
            new WeightedString("6", 51),
            new WeightedString("7", 120),
            new WeightedString("8", 93),
            new WeightedString("9", 99),
            new WeightedString("A", 9),
            new WeightedString("B", 1),
            new WeightedString("C", 30),
            new WeightedString("D", 1),
            new WeightedString("E", 1),
            new WeightedString("F", 6),
            new WeightedString("G", 3),
            new WeightedString("H", 1),
            new WeightedString("I", 1),
            new WeightedString("J", 12),
            new WeightedString("K", 1),
            new WeightedString("L", 1),
            new WeightedString("M", 3),
            new WeightedString("N", 1),
            new WeightedString("O", 1),
            new WeightedString("P", 1),
            new WeightedString("Q", 3),
            new WeightedString("R", 3),
            new WeightedString("S", 12),
            new WeightedString("T", 1),
            new WeightedString("U", 1),
            new WeightedString("V", 1),
            new WeightedString("W", 1),
            new WeightedString("X", 96),
            new WeightedString("Y", 3),
            new WeightedString("Z", 1)
        };

        //index of the origin symbol (must be last symbol entered)
        private static int originSymbolIndex = 0;

        //last index a symbol in the address can be
        private static int maxSymbolIndex = 38;

        public static DestinationDetails getDestinationData(int[] address) {
            ValidDestinations destinations;
            DestinationDetails destinationDetails;

            string stringifiedAddress = convertAddressToStringKey(address);

            //check the persistent data folder for the known address json
            if (!File.Exists(Application.persistentDataPath + knownAddressFilePath)) {
                //file does not exist

                //create a new destinations object
                destinations = new ValidDestinations();

                //generate a new set of destination details for the given address
                destinationDetails = generateDestinationDetails(generateDestinationDefinition(stringifiedAddress));

                //store the newly generated details under a string converted address key in the new destinations object
                destinations.addDestinationData(convertAddressToStringKey(address), destinationDetails);

                //serialize the destinations object to a string
                string destinationJson = JsonConvert.SerializeObject(destinations, Formatting.None);

                //write string to a new json file in the persistent data folder
                File.WriteAllText(Application.persistentDataPath + knownAddressFilePath, destinationJson);

                //return the new details
                return destinationDetails;
            }

            //file exists, load text into a string
            string storedString = File.ReadAllText(Application.persistentDataPath + knownAddressFilePath);
            
            //deserialize the string into a destinations object
            destinations = JsonConvert.DeserializeObject<ValidDestinations>(storedString);

            //using a string converted address key get the destination details
            destinationDetails = destinations.getDestinationData(convertAddressToStringKey(address));

            //if the data returned is null generate new details
            if (destinationDetails == null) {
                //generate a new set of destination details for the given address
                destinationDetails = generateDestinationDetails(generateDestinationDefinition(stringifiedAddress));

                //store the newly generated details under a string converted address key in the new destinations object
                destinations.addDestinationData(convertAddressToStringKey(address), destinationDetails);

                //serialize the destinations object to a string
                string destinationJson = JsonConvert.SerializeObject(destinations, Formatting.None);

                //write string to a new json file in the persistent data folder
                File.WriteAllText(Application.persistentDataPath + knownAddressFilePath, destinationJson);
            }

            return destinationDetails;
        }

        private static DestinationDetails generateDestinationDetails(DestinationDefinition destinationDefinition) {
            //currently only allowing planets with normal atmospheric environment to have a governing race
            if (destinationDefinition.environmentState == DestinationDefinition.EnvironmentState.NORMAL) {
                //load the destination profile into a text object
                TextAsset destinationProfileJson = Resources.Load<TextAsset>(destinationsProfileFilePath);

                //deserialize the destination profile json into an object
                DestinationProfile destinationProfile = JsonConvert.DeserializeObject<DestinationProfile>(destinationProfileJson.text);

                //check if destination is occupied
                if (((WeightedBool)WeightedValueSelector.selectValue(destinationProfile.occupyingRaceWeights)).value) {

                    //randomly select an environment type for the destination
                    RaceDefinitions.Race race = ((WeightedRace)WeightedValueSelector.selectValue(destinationProfile.raceWeights)).value;

                    return new DestinationDetails(destinationDefinition, race);
                }
            }

            //new destination without occupying race
            return new DestinationDetails(destinationDefinition, RaceDefinitions.Race.NONE);
        }

        private static DestinationDefinition generateDestinationDefinition(string stringifiedAddress) {
            //load the destination profile into a text object
            TextAsset destinationProfileJson = Resources.Load<TextAsset>(destinationsProfileFilePath);

            //deserialize the destination profile json into an object
            DestinationProfile destinationProfile = JsonConvert.DeserializeObject<DestinationProfile>(destinationProfileJson.text);

            //randomly select an environment type for the destination
            DestinationDefinition.EnvironmentState environmentState = ((WeightedEnvironmentState)WeightedValueSelector.selectValue(destinationProfile.environmentStateWeights)).value;

            return new DestinationDefinition(stringifiedAddress, generateRandomDesignation(), environmentState);
        }

        private static string generateRandomDesignation() {
            string designation = "P";

            System.Random random = new System.Random();

            //generates 2 random characters
            for (int i = 0; i < 2; i++) {
                designation += ((WeightedString)WeightedValueSelector.selectValue(designationCharacters)).value;
            }

            //adds hyphon separator
            designation += "-";

            //generates 3 random characters
            for (int i = 0; i < 3; i++) {
                designation += ((WeightedString)WeightedValueSelector.selectValue(designationCharacters)).value;
            }

            return designation;
        }

        public static string convertAddressToStringKey(int[] address) {
            string key = "" + address[0];

            //convert the given address to a string with each index separated by a $ (excudes origin)
            for (int i = 1; i < address.Length - 1; i++) {
                key += "$" + address[i];
            }

            return key;
        }

        public static int[] convertStringKeyToAddress(string addressKey) {
            string[] splitKey = addressKey.Split('$');
            int[] address = new int[splitKey.Length + 1];

            //convert all the split values to an int, adding to the address array
            for (int i = 0; i < splitKey.Length; i++) {
                address[i] = int.Parse(splitKey[i]);
            }

            //add the point of origin to the address
            address[address.Length - 1] = originSymbolIndex;

            return address;
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
            address[address.Length - 1] = originSymbolIndex;

            return address;
        }

        public static bool validateAddress(int[] address) {
            for (int i = 0; i < address.Length; i++) {
                //check that all ids in the address are valid
                if (address[i] < 0 || address[i] > maxSymbolIndex) {
                    return false;
                }
            }

            //check the last symbol index is the point of origin
            if (address[address.Length - 1] != originSymbolIndex) {
                return false;
            }

            //address is valid
            return true;
        }
    }
}
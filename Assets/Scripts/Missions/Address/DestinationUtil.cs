using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Text;

public static class DestinationUtil {
    private static string knownAddressFilePath = "/KnownAddressData.json";

    private static string[] designationCharacters = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

    public static DestinationDefinition retrieveKnownDestinationData(int[] address) {
        Destinations sevenSymbolDestinations;
        DestinationDefinition destinationDefinition;

        if (!File.Exists(Application.persistentDataPath + knownAddressFilePath)) {
            sevenSymbolDestinations = new Destinations();

            destinationDefinition = generateDestinationDefinition(address);

            sevenSymbolDestinations.addDestinationData(convertAddressToStringKey(address), destinationDefinition);

            string destinationJson = JsonConvert.SerializeObject(sevenSymbolDestinations, Formatting.None);

            File.WriteAllText(Application.persistentDataPath + knownAddressFilePath, destinationJson);

            return destinationDefinition;
        }

        string storedString = File.ReadAllText(Application.persistentDataPath + knownAddressFilePath);
        sevenSymbolDestinations = JsonConvert.DeserializeObject<Destinations>(storedString);

        destinationDefinition = sevenSymbolDestinations.retrieveDestinationData(convertAddressToStringKey(address));

        if(destinationDefinition == null) {
            destinationDefinition = generateDestinationDefinition(address);

            sevenSymbolDestinations.addDestinationData(convertAddressToStringKey(address), destinationDefinition);

            string destinationJson = JsonConvert.SerializeObject(sevenSymbolDestinations, Formatting.None);

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

        for (int i = 0; i < 2; i++) {
            designation += designationCharacters[random.Next(0, designationCharacters.Length)];
        }

        designation += "-";

        for (int i = 0; i < 3; i++) {
            designation += designationCharacters[random.Next(0, designationCharacters.Length)];
        }

        return designation;
    }

    public static string convertAddressToStringKey(int[] address) {
        string key = "";

        for(int i = 0; i < address.Length - 1; i++) {
            key += address[i] + "-";
        }
        key += address[address.Length - 1];

        return key;
    }
}

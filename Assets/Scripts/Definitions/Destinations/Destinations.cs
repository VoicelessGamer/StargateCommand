using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Destinations {
    public Dictionary<string, DestinationDefinition> destinations;

    public Destinations() {
        destinations = new Dictionary<string, DestinationDefinition>();
    }
    public void addDestinationData(string addressKey, DestinationDefinition destinationDefinition) {
        destinations[addressKey] = destinationDefinition;
    }

    public DestinationDefinition retrieveDestinationData(string addressKey) {
        if(destinations.ContainsKey(addressKey)) {
            return destinations[addressKey];
        }

         return null;
    }
}

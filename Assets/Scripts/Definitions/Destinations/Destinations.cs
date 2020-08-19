using System.Collections.Generic;

namespace Definitions.Destinations {
    [System.Serializable]
    public class Destinations {
        //key = stringified representation of the address
        //value = details regarding the destination at given address
        public Dictionary<string, DestinationDefinition> destinations;

        public Destinations() {
            destinations = new Dictionary<string, DestinationDefinition>();
        }

        public void addDestinationData(string addressKey, DestinationDefinition destinationDefinition) {
            //adds a new record of destination details
            destinations[addressKey] = destinationDefinition;
        }

        public DestinationDefinition getDestinationData(string addressKey) {
            //check if the address key exists
            if (destinations.ContainsKey(addressKey)) {
                //return the resulting details
                return destinations[addressKey];
            }

            //no matching key found
            return null;
        }
    }
}
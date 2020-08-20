using System.Collections.Generic;

namespace Definitions.Destinations {
    [System.Serializable]
    public class ValidDestinations {
        //key = stringified representation of the address
        //value = details regarding the destination at given address
        public Dictionary<string, DestinationDetails> destinations;

        public ValidDestinations() {
            destinations = new Dictionary<string, DestinationDetails>();
        }

        public void addDestinationData(string addressKey, DestinationDetails destinationDetails) {
            //adds a new record of destination details
            destinations[addressKey] = destinationDetails;
        }

        public DestinationDetails getDestinationData(string addressKey) {
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
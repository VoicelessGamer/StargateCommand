using UnityEngine;
using Definitions.Destinations;

namespace Missions.Address {
    public class AddressManager : MonoBehaviour {

        public AddressInput addressInput;

        public DestinationDetails getDestinationDetails() {
            /*int[] address = addressInput.getAddress();

            if(address == null) {
                //Address invalid
                return null;
            }*/

            int[] address = DestinationUtil.generateRandomAddress(7);

            //check the address is a valid selection
            if (!DestinationUtil.validateAddress(address)) {
                return null;
            }

            //retrieve the destination details for the given address
            DestinationDetails destinationDetails = DestinationUtil.getDestinationData(address);

            return destinationDetails;
        }
    }
}
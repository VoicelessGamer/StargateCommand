﻿using UnityEngine;
using Definitions.Destinations;

namespace Missions.Address {
    public class AddressManager : MonoBehaviour {

        public AddressInput addressInput;

        //index of the origin symbol (must be last symbol entered)
        private int originSymbolIndex = 0;

        //last index a symbol in the address can be
        private int maxSymbolIndex = 38;

        public DestinationDetails getDestinationDetails() {
            /*int[] address = addressInput.getAddress();

            if(address == null) {
                //Address invalid
                return null;
            }*/

            int[] address = DestinationUtil.generateRandomAddress(7);

            //check the address is a valid selection
            if (!validateAddress(address)) {
                return null;
            }

            //retrieve the destination details for the given address
            DestinationDetails destinationDetails = DestinationUtil.getDestinationData(address);

            Debug.Log(destinationDetails.ToString());

            return destinationDetails;
        }

        public bool validateAddress(int[] address) {
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddressManager : MonoBehaviour {

    public AddressInput addressInput;

    public void addressEntered() {
        int[] address = addressInput.retrieveAddress();

        if(address == null) {
            //Address invalid
            return;
        }

        DestinationDefinition destinationDefinition = DestinationUtil.retrieveKnownDestinationData(address);

        Debug.Log(destinationDefinition.ToString());
    }
}

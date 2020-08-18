using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DestinationDefinition {

    public string designation;

    public int[] address;

    public DestinationDefinition(string designation, int[] address) {
        this.designation = designation;
        this.address = address;
    }

    public override string ToString() {
        string str = "Designation: " + this.designation + ", Address: [";

        for(int i = 0; i < address.Length - 1; i++) {
            str += address[i] + ", ";
        }

        str += address[address.Length - 1] + "]";

        return str;
    }
}

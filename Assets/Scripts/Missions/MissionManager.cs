﻿using UnityEngine;
using Missions.Address;
using Definitions.Destinations;
using Definitions.Missions;

namespace Missions {
    public class MissionManager : MonoBehaviour {

        public AddressManager addressManager;

        public void generateNewMission() {
            DestinationDetails destinationDetails = addressManager.getDestinationDetails();

            MissionUtil.generateNewMission(MissionDefinitions.MissionType.EXPLORATION);
        }
    }
}
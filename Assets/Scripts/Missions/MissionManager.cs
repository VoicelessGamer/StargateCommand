using UnityEngine;
using Missions.Address;
using Definitions.Destinations;
using Definitions.Missions;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Missions {
    public class MissionManager : MonoBehaviour {

        public AddressManager addressManager;

        public GameObject availableMissionPanel;

        public Transform canvas;

        //list of the sprite images in index order
        public List<Sprite> symbolSprites;

        private int createdMissions = 0;

        public void generateNewMission() {
            //get the planet information
            DestinationDetails destinationDetails = addressManager.getDestinationDetails();

            //generate a new set of mission details
            MissionDetails missionDetails = MissionUtil.generateNewMission(MissionDefinition.MissionType.EXPLORATION);

            Debug.Log(destinationDetails.ToString());
            Debug.Log(missionDetails.ToString());

            //create a panel displaying the created missions details
            createAvailableMissionPanel(missionDetails, destinationDetails);

            createdMissions++;
        }

        public void createAvailableMissionPanel(MissionDetails missionDetails, DestinationDetails destinationDetails) {
            Transform availablePanel = Instantiate(availableMissionPanel, new Vector3(420, 270 - (140 * createdMissions), 0), Quaternion.identity).transform;
            availablePanel.SetParent(canvas, false);

            string title = missionDetails.missionDefinition.missionType.ToString() + " on " + destinationDetails.destinationDefinition.designation;

            availablePanel.Find("Title").GetComponent<Text>().text = title;
            //availablePanel.Find("Symbol1").GetComponent<Image>().sprite = symbolSprites[destinationDetails.destinationDefinition.];

            availablePanel.Find("MissionTime").GetComponent<Text>().text = missionDetails.missionTime + " seconds";
            availablePanel.Find("PassRate").GetComponent<Text>().text = "" + (missionDetails.passRate * 100);
            availablePanel.Find("SelectButton").GetComponent<Button>().onClick.AddListener(() => { onMissionActivated(missionDetails); });
        }

        public void onMissionActivated(MissionDetails missionDetails) {
            Debug.Log(missionDetails.ToString());
        }
    }
}
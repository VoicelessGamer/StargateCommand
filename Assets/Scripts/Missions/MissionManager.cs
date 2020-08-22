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
            //converts the string address to an integer array to be used with the sprite list
            int[] address = DestinationUtil.convertStringKeyToAddress(destinationDetails.destinationDefinition.address);

            //temporarily instantiating the new available mission panel in a specific position on screen
            Transform availablePanel = Instantiate(availableMissionPanel, new Vector3(420, 270 - (140 * createdMissions), 0), Quaternion.identity).transform;
            availablePanel.SetParent(canvas, false);

            //Set the panel title to something meaningful
            string title = missionDetails.missionDefinition.missionType.ToString() + " on " + destinationDetails.destinationDefinition.designation;
            availablePanel.Find("Title").GetComponent<Text>().text = title;

            //using the convert string address set all the address symbol images
            availablePanel.Find("Symbol1").GetComponent<Image>().sprite = symbolSprites[address[0]];
            availablePanel.Find("Symbol2").GetComponent<Image>().sprite = symbolSprites[address[1]];
            availablePanel.Find("Symbol3").GetComponent<Image>().sprite = symbolSprites[address[2]];
            availablePanel.Find("Symbol4").GetComponent<Image>().sprite = symbolSprites[address[3]];
            availablePanel.Find("Symbol5").GetComponent<Image>().sprite = symbolSprites[address[4]];
            availablePanel.Find("Symbol6").GetComponent<Image>().sprite = symbolSprites[address[5]];
            availablePanel.Find("Symbol7").GetComponent<Image>().sprite = symbolSprites[address[6]];

            //converting the mission time to a more readable text
            System.TimeSpan time = System.TimeSpan.FromSeconds(missionDetails.missionTime);
            string missionTime = "Mission Time: ";
            missionTime += time.Days > 0 ? time.Days + "d " : "";
            missionTime += time.Hours > 0 ? time.Hours + "h " : "";
            missionTime += time.Minutes > 0 ? time.Minutes + "m " : "";
            missionTime += time.Seconds > 0 ? time.Seconds + "s" : "";

            //set the mission time text on the panel
            availablePanel.Find("MissionTime").GetComponent<Text>().text = missionTime;

            //set the pass rate text on the panel
            availablePanel.Find("PassRate").GetComponent<Text>().text = "Pass Chance: " + (missionDetails.passRate * 100) + "%";

            //add a new listener to the selection button for the panel which calls the onMissionActivated function
            //passing in the mission details for this mission
            availablePanel.Find("SelectButton").GetComponent<Button>().onClick.AddListener(() => { onMissionActivated(missionDetails); });
        }

        public void onMissionActivated(MissionDetails missionDetails) {
            Debug.Log(missionDetails.ToString());
        }
    }
}
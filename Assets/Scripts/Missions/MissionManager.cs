using UnityEngine;
using Missions.Address;
using Definitions.Destinations;
using Definitions.Missions;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System;

namespace Missions {
    public class MissionManager : MonoBehaviour {

        private static string availableMissionsPath = "/AvailableMissions.json";

        private static string activeMissionsPath = "/ActiveMissions.json";

        public AddressManager addressManager;

        public GameObject availableMissionPanel;

        public Transform availableMissionView;

        public GameObject activeMissionPanel;

        public Transform activeMissionView;

        //list of the sprite images in index order
        public List<Sprite> symbolSprites;

        private AvailableMissions availableMissions;

        private void Start() {
            //retrieve all stored avaiable missions
            getAvailableMissions();
            //add all the current available mission to the view panel
            initialiseAvailableMissionView();
        }

        private void initialiseAvailableMissionView() {
            //add all the current available mission to the view panel
            for(int i = 0; i < availableMissions.missions.Count; i++) {
                //create a panel displaying the current missions details
                createAvailableMissionPanel(availableMissions.missions[i]);
            }
        }

        public void generateNewMission() {
            //get the planet information
            DestinationDetails destinationDetails = addressManager.getDestinationDetails();

            //generate a new set of mission details
            MissionDetails missionDetails = MissionUtil.generateNewMission(destinationDetails);

            //Debug.Log(missionDetails.ToString());

            //store the new available mission to json
            addAvailableMission(missionDetails);

            //create a panel displaying the created missions details
            createAvailableMissionPanel(missionDetails);
        }

        public void createAvailableMissionPanel(MissionDetails missionDetails) {
            //converts the string address to an integer array to be used with the sprite list
            int[] address = DestinationUtil.convertStringKeyToAddress(missionDetails.destinationDetails.destinationDefinition.address);

            //temporarily instantiating the new available mission panel in a specific position on screen
            Transform availablePanel = Instantiate(availableMissionPanel, Vector3.zero, Quaternion.identity).transform;
            availablePanel.SetParent(availableMissionView, false);

            //Set the panel title to something meaningful
            string title = missionDetails.missionDefinition.missionType.ToString() + " on " + missionDetails.destinationDetails.destinationDefinition.designation;
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

            //get the current time in UTC
            DateTime timeNow = DateTime.UtcNow;

            //add the mission time to the current time to get the mission complete time
            DateTime completionTime = timeNow.AddSeconds(missionDetails.missionTime);

            //create a new panel in the active panel view
            GameObject activeMissionPanel = createActiveMissionPanel(missionDetails, completionTime);

            //add and set up the active mission objecty
            ActiveMission activeMission = (ActiveMission)activeMissionPanel.AddComponent(typeof(ActiveMission));
            activeMission.initialise(missionDetails, completionTime);

            Debug.Log(activeMission.ToString());
        }

        public GameObject createActiveMissionPanel(MissionDetails missionDetails, DateTime completionTime) {
            //converts the string address to an integer array to be used with the sprite list
            int[] address = DestinationUtil.convertStringKeyToAddress(missionDetails.destinationDetails.destinationDefinition.address);

            //temporarily instantiating the new active mission panel in a specific position on screen
            Transform activePanel = Instantiate(activeMissionPanel, Vector3.zero, Quaternion.identity).transform;
            activePanel.SetParent(activeMissionView, false);

            //Set the panel title to something meaningful
            string title = missionDetails.missionDefinition.missionType.ToString() + " on " + missionDetails.destinationDetails.destinationDefinition.designation;
            activePanel.Find("Title").GetComponent<Text>().text = title;

            //using the convert string address set all the address symbol images
            activePanel.Find("Symbol1").GetComponent<Image>().sprite = symbolSprites[address[0]];
            activePanel.Find("Symbol2").GetComponent<Image>().sprite = symbolSprites[address[1]];
            activePanel.Find("Symbol3").GetComponent<Image>().sprite = symbolSprites[address[2]];
            activePanel.Find("Symbol4").GetComponent<Image>().sprite = symbolSprites[address[3]];
            activePanel.Find("Symbol5").GetComponent<Image>().sprite = symbolSprites[address[4]];
            activePanel.Find("Symbol6").GetComponent<Image>().sprite = symbolSprites[address[5]];
            activePanel.Find("Symbol7").GetComponent<Image>().sprite = symbolSprites[address[6]];

            //set the mission time text on the panel
            activePanel.Find("MissionTime").GetComponent<Text>().text = completionTime.ToString();

            //set the pass rate text on the panel
            activePanel.Find("PassRate").GetComponent<Text>().text = "Pass Chance: " + (missionDetails.passRate * 100) + "%";

            //add a new listener to the selection button for the panel which calls the onMissionActivated function
            //passing in the mission details for this mission
            //activePanel.Find("SelectButton").GetComponent<Button>().onClick.AddListener(() => { onMissionActivated(activeMission.missionDetails); });

            return activePanel.gameObject;
        }

        private void getAvailableMissions() {

            //check the persistent data folder for the available missions json
            if (!File.Exists(Application.persistentDataPath + availableMissionsPath)) {
                //file does not exist

                //create a new AvailableMissions object
                this.availableMissions = new AvailableMissions();

                //save the current available missions object to storage
                //eventually move this to some type of saving functionality
                saveAvailableMissions();
            } else {
                //file exists, load text into a string
                string storedString = File.ReadAllText(Application.persistentDataPath + availableMissionsPath);

                //deserialize and return the string into an AvailableMissions object
                this.availableMissions = JsonConvert.DeserializeObject<AvailableMissions>(storedString);
            }
        }

        private void addAvailableMission(MissionDetails missionDetails) {
            //add details to the AvailableMissions object
            availableMissions.missions.Add(missionDetails);

            //save the current available missions object to storage
            //eventually move this to some type of saving functionality
            saveAvailableMissions();
        }

        private void saveAvailableMissions() {
            //serialize the availableMissions object to a string
            string availableMissionsJson = JsonConvert.SerializeObject(availableMissions, Formatting.None);

            //write string to a new json file in the persistent data folder
            File.WriteAllText(Application.persistentDataPath + availableMissionsPath, availableMissionsJson);
        }
    }
}
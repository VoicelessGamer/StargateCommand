﻿using UnityEngine;
using Newtonsoft.Json;
using Definitions.Missions;
using Definitions.Destinations;
using System.IO;

namespace Missions {
    public class MissionUtil {
        private static string missionDefinitionPath = "Json/MissionDefinitions";

        public static MissionDetails generateNewMission(DestinationDetails destinationDetails) {
            //retrieve the matching mission definition (currently always exploration for testing)
            MissionDefinition missionDefinition = getMissionDefinition(MissionDefinition.MissionType.EXPLORATION);

            //generate mission information
            MissionDetails missionDetails = generateMissionDetails(missionDefinition, destinationDetails);

            return missionDetails;
        }

        public static MissionDefinition getMissionDefinition(MissionDefinition.MissionType missionType) {
            //load the mission definitions into a text object
            TextAsset missionDefinitionJson = Resources.Load<TextAsset>(missionDefinitionPath);

            //deserialize the mission definitions json into an object
            MissionDefinitions missionDefinitions = JsonConvert.DeserializeObject<MissionDefinitions>(missionDefinitionJson.text);

            //return the matching definition for the given type
            return missionDefinitions.definitions[missionType];
        }

        public static MissionDetails generateMissionDetails(MissionDefinition missionDefinition, DestinationDetails destinationDetails) {
            //generate the time it will take to complete this mission (5 seconds - 2 days)
            long missionTime = new System.Random().Next(5, 172800);

            //generate the pass rate chance of completing this mission
            float passRate = missionDefinition.basePassRate;

            //generate and return a new set of mission details using the generated data
            return new MissionDetails(missionDefinition, destinationDetails, missionTime, passRate);
        }

        /*public static AvailableMissions getAvailableMissions() {
            AvailableMissions availableMissions;

            //check the persistent data folder for the available missions json
            if (!File.Exists(Application.persistentDataPath + availableMissionsPath)) {
                //file does not exist

                //create a new AvailableMissions object
                availableMissions = new AvailableMissions();

                //serialize the availableMissions object to a string
                string availableMissionsJson = JsonConvert.SerializeObject(availableMissions, Formatting.None);

                //write string to a new json file in the persistent data folder
                File.WriteAllText(Application.persistentDataPath + availableMissionsPath, availableMissionsJson);

                //return the available missions object
                return availableMissions;
            }

            //file exists, load text into a string
            string storedString = File.ReadAllText(Application.persistentDataPath + availableMissionsPath);

            //deserialize and return the string into an AvailableMissions object
            return JsonConvert.DeserializeObject<AvailableMissions>(storedString);
        }

        public static void addAvailableMissions(MissionDetails missionDetails) {
            //retrieve the AvailableMissions object
            AvailableMissions availableMissions = getAvailableMissions();

            //add details to the AvailableMissions object
            availableMissions.missions.Add(missionDetails);

            //serialize the availableMissions object to a string
            string availableMissionsJson = JsonConvert.SerializeObject(availableMissions, Formatting.None);

            //write string to a new json file in the persistent data folder
            File.WriteAllText(Application.persistentDataPath + availableMissionsPath, availableMissionsJson);
        }*/
    }
}

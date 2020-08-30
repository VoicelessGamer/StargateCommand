using UnityEngine;
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
    }
}

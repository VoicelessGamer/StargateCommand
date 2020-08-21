using UnityEngine;
using Newtonsoft.Json;
using Definitions.Missions;

namespace Missions {
    public class MissionUtil {
        private static string missionDefinitionPath = "Json/MissionDefinitions";

        public static MissionDetails generateNewMission(MissionDefinition.MissionType missionType) {
            //retrieve the matching mission definition
            MissionDefinition missionDefinition = getMissionDefinition(missionType);

            //generate mission information
            MissionDetails missionDetails = generateMissionDetails(missionDefinition);

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

        public static MissionDetails generateMissionDetails(MissionDefinition missionDefinition) {
            //generate the time it will take to complete this mission
            long missionTime = new System.Random().Next(5, 75);

            //generate the pass rate chance of completing this mission
            float passRate = missionDefinition.basePassRate;

            //generate and return a new set of mission details using the generated data
            return new MissionDetails(missionDefinition, missionTime, passRate);
        }
    }
}

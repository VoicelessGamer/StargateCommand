using UnityEngine;
using Newtonsoft.Json;
using Definitions.Missions;

namespace Missions {
    public class MissionUtil {
        private static string missionDefinitionPath = "Json/MissionDefinitions";

        public static void generateNewMission(MissionDefinitions.MissionType missionType) {
            //retrieve the matching mission definition
            MissionDefinition missionDefinition = getMissionDefinition(missionType);

            Debug.Log(missionDefinition.ToString());
        }

        public static MissionDefinition getMissionDefinition(MissionDefinitions.MissionType missionType) {
            //load the mission definitions into a text object
            TextAsset missionDefinitionJson = Resources.Load<TextAsset>(missionDefinitionPath);

            //deserialize the mission definitions json into an object
            MissionDefinitions missionDefinitions = JsonConvert.DeserializeObject<MissionDefinitions>(missionDefinitionJson.text);

            //return the matching definition for the given type
            return missionDefinitions.definitions[missionType];
        }
    }
}

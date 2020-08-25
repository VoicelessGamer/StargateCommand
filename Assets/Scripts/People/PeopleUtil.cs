using UnityEngine;
using Newtonsoft.Json;
using Definitions.People;

namespace People {
    public static class PeopleUtil {
        private static string ranksFilePath = "Json/Ranks";

        private static Rank getRankDetails(int rankIndex) {
            //load the ranks json object
            TextAsset ranksJson = Resources.Load<TextAsset>(ranksFilePath);

            //deserialize the ranks json into an object
            Ranks ranks = JsonConvert.DeserializeObject<Ranks>(ranksJson.text);

            return ranks.ranks[rankIndex];
        }
    }
}
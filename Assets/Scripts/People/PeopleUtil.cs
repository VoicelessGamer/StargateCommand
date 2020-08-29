using UnityEngine;
using Newtonsoft.Json;
using Definitions.People;
using System.IO;

namespace People {
    public static class PeopleUtil {
        private static string ranksFilePath = "Json/Ranks";

        private static string employedMemberPath = "/EmployedMembers.json";

        private static string teamsPath = "/Teams.json";

        public static Rank getRankDetails(int rankIndex) {
            //load the ranks json object
            TextAsset ranksJson = Resources.Load<TextAsset>(ranksFilePath);

            //deserialize the ranks json into an object
            Ranks ranks = JsonConvert.DeserializeObject<Ranks>(ranksJson.text);

            return ranks.ranks[rankIndex];
        }

        public static EmployedMembers getEmployedMembers() {
            EmployedMembers employedMembers;

            //check the persistent data folder for the employed members json
            if (!File.Exists(Application.persistentDataPath + employedMemberPath)) {
                //file does not exist

                //create a new EmployedMembers object
                employedMembers = new EmployedMembers();
            } else {
                //file exists, load text into a string
                string storedString = File.ReadAllText(Application.persistentDataPath + employedMemberPath);

                //deserialize and return the string into an EmployedMembers object
                employedMembers = JsonConvert.DeserializeObject<EmployedMembers>(storedString);
            }

            return employedMembers;
        }

        public static void saveNewTeamMember(TeamMember teamMember) {
            //retrieve the employed members from storage
            EmployedMembers employedMembers = getEmployedMembers();

            //add the new member to the list
            employedMembers.members.Add(teamMember);

            //serialize the EmployedMembers object to a string
            string employedMembersJson = JsonConvert.SerializeObject(employedMembers, Formatting.None);

            //write string to a new json file in the persistent data folder
            File.WriteAllText(Application.persistentDataPath + employedMemberPath, employedMembersJson);
        }

        public static Teams getTeams() {
            Teams teams;

            //check the persistent data folder for the Teams json
            if (!File.Exists(Application.persistentDataPath + teamsPath)) {
                //file does not exist

                //create a new Teams object
                teams = new Teams();

                saveTeams(teams);
            } else {
                //file exists, load text into a string
                string storedString = File.ReadAllText(Application.persistentDataPath + teamsPath);

                //deserialize and return the string into an Teams object
                teams = JsonConvert.DeserializeObject<Teams>(storedString);
            }

            return teams;
        }

        public static void saveTeams(Teams teams) {

            //serialize the Teams object to a string
            string teamsJson = JsonConvert.SerializeObject(teams, Formatting.None);

            //write string to a new json file in the persistent data folder
            File.WriteAllText(Application.persistentDataPath + teamsPath, teamsJson);
        }
    }
}
using System.Collections.Generic;

namespace Definitions.People {
    [System.Serializable]
    public class Teams {

        public Dictionary<int, Team> teams;

        public Teams() {
            this.teams = new Dictionary<int, Team>();
        }

        public Teams(Dictionary<int, Team> teams) {
            this.teams = teams;
        }

        public override string ToString() {
            string str = "Teams: [";
            foreach(int teamIndex in teams.Keys) {
                str += "{" + teamIndex + ": {" + teams[teamIndex].ToString() + "}}";
            }
            return str + "]";
        }
    }
}
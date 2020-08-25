using System.Collections.Generic;

namespace Definitions.People {
    [System.Serializable]
    public class Team {

        public string name;

        public List<TeamMember> teamMembers;

        public Team() {
            this.name = "UNKNOWN";
            this.teamMembers = new List<TeamMember>();
        }

        public Team(string name, List<TeamMember> teamMembers) {
            this.name = name;
            this.teamMembers = teamMembers;
        }

        public override string ToString() {
            return "Name: " + this.name;
        }
    }
}
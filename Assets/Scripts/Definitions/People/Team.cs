using System;
using System.Collections.Generic;

namespace Definitions.People {
    [System.Serializable]
    public class Team {
        public bool locked;

        public List<TeamMember> teamMembers;

        public Team() {
            this.locked = true;
            this.teamMembers = new List<TeamMember>();
        }

        public Team(bool locked, List<TeamMember> teamMembers) {
            this.locked = locked;
            this.teamMembers = teamMembers;
        }
    }
}
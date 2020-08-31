using System.Collections.Generic;

namespace Definitions.People {
    [System.Serializable]
    public class Team {
        public bool locked;

        public List<string> teamMemberKeys;

        public Team() {
            this.locked = true;
            this.teamMemberKeys = new List<string>();
        }

        public Team(bool locked, List<string> teamMemberKeys) {
            this.locked = locked;
            this.teamMemberKeys = teamMemberKeys;
        }
    }
}
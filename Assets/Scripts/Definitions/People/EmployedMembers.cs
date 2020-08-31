using System.Collections.Generic;

namespace Definitions.People {
    [System.Serializable]
    public class EmployedMembers {

        public Dictionary<string, TeamMember> members;

        public EmployedMembers() {
            this.members = new Dictionary<string, TeamMember>();
        }

        public EmployedMembers(Dictionary<string, TeamMember> members) {
            this.members = members;
        }
    }
}
using System.Collections.Generic;

namespace Definitions.People {
    [System.Serializable]
    public class EmployedMembers {

        public List<TeamMember> members;

        public EmployedMembers() {
            this.members = new List<TeamMember>();
        }

        public EmployedMembers(List<TeamMember> members) {
            this.members = members;
        }
    }
}
using System.Collections.Generic;

namespace Definitions.Missions {
    public class AvailableMissions {
        public List<MissionDetails> missions;
        public AvailableMissions() {
            this.missions = new List<MissionDetails>();
        }

        public AvailableMissions(List<MissionDetails> missions) {
            this.missions = missions;
        }
    }
}

using System.Collections.Generic;

namespace Definitions.Missions {
    [System.Serializable]
    public class ActiveMissions {
        //storing active mission details under a team index
        //assuming teams can only be on 1 mission at a time
        public Dictionary<int, ActiveMissionDetails> missions;

        public ActiveMissions() {
            this.missions = new Dictionary<int, ActiveMissionDetails>();
        }

        public ActiveMissions(Dictionary<int, ActiveMissionDetails> missions) {
            this.missions = missions;
        }
    }
}

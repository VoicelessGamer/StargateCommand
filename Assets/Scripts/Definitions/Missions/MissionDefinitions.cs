using System.Collections.Generic;

namespace Definitions.Missions {
    public class MissionDefinitions {
        public enum MissionType {
            EXPLORATION,
            RECON,
            ASSAULT,
            DEFENCE,
            NEGOTIATION,
            CAPTURE,
            EXTRACTION,
            RESEARCH
        }

        public Dictionary<MissionType, MissionDefinition> definitions;
    }
}

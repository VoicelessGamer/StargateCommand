using System.Collections.Generic;

namespace Definitions.Races {
    public class RaceDefinitions {
        public enum Race {
            NONE,
            HUMAN,
            JAFFA,
            GOAULD,
            ABYDONIANS,
            LANGARANS,
            REBEL_JAFFA,
            TOLLAN,
            TOKRA,
            SODAN,
            NOX,
            FURLINGS,
            ASGUARD,
            ANCIENTS
        }

        //key = race name
        //value = race details
        public Dictionary<Race, RaceDefinition> definitions;
    }
}

using System.Collections.Generic;

namespace Definitions.People {
    [System.Serializable]
    public class Ranks {

        public Dictionary<int, Rank> ranks;

        public Ranks() {
            this.ranks = new Dictionary<int, Rank>();
        }

        public Ranks(Dictionary<int, Rank> ranks) {
            this.ranks = ranks;
        }
    }
}
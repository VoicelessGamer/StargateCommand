namespace Definitions.People {
    [System.Serializable]
    public class Rank {

        public string rankName;

        public string abbreviation;

        public Rank() {
            this.rankName = "";
            this.abbreviation = "";
        }

        public Rank(string rankName, string abbreviation) {
            this.rankName = rankName;
            this.abbreviation = abbreviation;
        }
    }
}
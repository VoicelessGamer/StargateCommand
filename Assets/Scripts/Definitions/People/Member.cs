namespace Definitions.People {
    [System.Serializable]
    public class Member {

        //maps to a rank object stored in the Ranks class
        public int rank;

        public string forename;

        public string surname;

        public Member(int rank, string forename, string surname) {
            this.rank = rank;
            this.forename = forename;
            this.surname = surname;
        }

        public override string ToString() {
            return "Rank: " + this.rank + ", Name: " + this.forename + " " + this.surname;
        }
    }
}
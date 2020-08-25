namespace Definitions.People {
    [System.Serializable]
    public class Member {

        //maps to a rank object stored in the Ranks class
        public int rank;

        public string name;

        public Member(int rank, string name) {
            this.rank = rank;
            this.name = name;
        }

        public override string ToString() {
            return "Rank: " + this.rank + ", Name: " + this.name;
        }
    }
}
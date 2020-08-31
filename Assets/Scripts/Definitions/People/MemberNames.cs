using System.Collections.Generic;

namespace Definitions.People {
    [System.Serializable]
    public class MemberNames {

        public List<string> maleNames;
        public List<string> femaleNames;
        public List<string> surnames;

        public MemberNames(List<string> maleNames, List<string> femaleNames, List<string> surnames) {
            this.maleNames = maleNames;
            this.femaleNames = femaleNames;
            this.surnames = surnames;
        }
    }
}
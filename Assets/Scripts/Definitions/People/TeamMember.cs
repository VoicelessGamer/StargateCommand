using Definitions.Items;

namespace Definitions.People {
    [System.Serializable]
    public class TeamMember: Member {

        public Weapon primaryWeapon;

        public Weapon secondaryWeapon;

        public TeamMember(int rank, string name, Weapon primaryWeapon, Weapon secondaryWeapon): base(rank, name) {
            this.primaryWeapon = primaryWeapon;
            this.secondaryWeapon = secondaryWeapon;
        }

        public override string ToString() {
            return base.ToString() + ", Primary: {" + primaryWeapon.ToString() + "}, Secondary: {" + secondaryWeapon.ToString() + "}";
        }
    }
}
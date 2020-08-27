using Definitions.Weapons;

namespace Definitions.People {
    [System.Serializable]
    public class TeamMember: Member {

        public WeaponDefinition primaryWeapon;

        public WeaponDefinition secondaryWeapon;

        public TeamMember(int rank, string forename, string surname, WeaponDefinition primaryWeapon, WeaponDefinition secondaryWeapon): base(rank, forename, surname) {
            this.primaryWeapon = primaryWeapon;
            this.secondaryWeapon = secondaryWeapon;
        }

        public override string ToString() {
            return base.ToString() + ", Primary: {" + primaryWeapon.ToString() + "}, Secondary: {" + secondaryWeapon.ToString() + "}";
        }
    }
}
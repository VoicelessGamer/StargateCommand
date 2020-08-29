using Definitions.Weapons;

namespace Definitions.People {
    [System.Serializable]
    public class TeamMember: Member {

        public WeaponDefinition primaryWeapon;

        public WeaponDefinition secondaryWeapon;

        //change below object to be correct classes
        public WeaponDefinition throwableWeapon;
        public WeaponDefinition armour;

        public TeamMember(int rank, string forename, string surname, 
            WeaponDefinition primaryWeapon, WeaponDefinition secondaryWeapon, WeaponDefinition throwableWeapon, WeaponDefinition armour) : base(rank, forename, surname) {
            this.primaryWeapon = primaryWeapon;
            this.secondaryWeapon = secondaryWeapon;
            this.throwableWeapon = throwableWeapon;
            this.armour = armour;
        }

        public override string ToString() {
            return base.ToString() + ", Primary: {" + primaryWeapon.ToString() + "}, Secondary: {" + secondaryWeapon.ToString() + "}"
                 + "}, Throwable: {" + throwableWeapon.ToString() + "}" + "}, Armour: {" + armour.ToString() + "}";
        }
    }
}
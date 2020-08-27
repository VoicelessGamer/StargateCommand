using Core;

namespace Definitions.Weapons {
    [System.Serializable]
    public class WeaponDefinition : RarityObject {

        public enum WeaponType {
            PRIMARY,
            SECONDARY,
            THROWABLE
        }

        public enum DamageType {
            BALLISTIC,
            ENERGY,
            EXPLOSIVE
        }

        public string name;

        public float minimumDamage;

        public float maximumDamage;

        public WeaponType weaponType;

        public DamageType damageType;

        public override string ToString() {
            return base.ToString() + ", Name: " + this.name + ", Minimum Damage: " + this.minimumDamage + ", Maximum Damage: " + this.maximumDamage + ", Weapon Type: " + this.weaponType.ToString() + ", Damage Type: " + this.damageType.ToString();
        }

    }
}
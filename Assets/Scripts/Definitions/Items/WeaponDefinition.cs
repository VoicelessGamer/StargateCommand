namespace Definitions.Items {
    [System.Serializable]
    public class WeaponDefinition : ItemDefinition {

        public enum WeaponType {
            PRIMARY,
            SECONDARY
        }

        public enum DamageType {
            BALLISTIC,
            ENERGY,
            EXPLOSIVE
        }

        public float minimumDamage;

        public float maximumDamage;

        public WeaponType weaponType;

        public DamageType damageType;

        public override string ToString() {
            return base.ToString() + ", Minimum Damage: " + this.minimumDamage + ", Maximum Damage: " + this.maximumDamage + ", Weapon Type: " + this.weaponType.ToString() + ", Damage Type: " + this.damageType.ToString();
        }

    }
}
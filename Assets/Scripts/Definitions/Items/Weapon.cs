namespace Definitions.Items {
    public class Weapon {

        public string name { get; set; }

        public float damage { get; private set; }

        public WeaponDefinition weaponDefinition { get; private set; }

        public Weapon(string name, float damage, WeaponDefinition weaponDefinition) {
            this.name = name;
            this.damage = damage;
            this.weaponDefinition = weaponDefinition;
        }

        public override string ToString() {
            return "Name: " + this.name + ", Damage: " + this.damage + ", Weapon Definition: { " + this.weaponDefinition.ToString() + " }";
        }
    }
}

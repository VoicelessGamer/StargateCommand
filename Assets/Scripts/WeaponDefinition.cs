[System.Serializable]
public class WeaponDefinition {

    public enum Type {
        BALLISTIC,
        ENERGY        
    }

    public string name;

    public double minimumDamage;

    public double maximumDamage;

    public Type type;

    public string getWeaponDetails() {
        return "Name: " + this.name + ", Minimum Damage: " + this.minimumDamage + ", Maximum Damage: " + this.maximumDamage + ", Type: " + this.type.ToString();
    }
}

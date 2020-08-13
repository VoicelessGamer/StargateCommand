[System.Serializable]
public abstract class RarityObject {
    public enum Rarity {
        COMMON,
        UNCOMMON,
        RARE,
        VERY_RARE,
        EXTREMELY_RARE
    }

    public Rarity rarity;

    public override string ToString() {
        return "Rarity: " + rarity.ToString();
    }
}

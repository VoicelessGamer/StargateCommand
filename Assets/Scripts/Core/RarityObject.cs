namespace Core {
    [System.Serializable]
    public abstract class RarityObject {
        public enum Rarity {
            COMMON,
            UNCOMMON,
            RARE,
            VERY_RARE,
            LEGENDARY
        }

        public Rarity rarity;

        public override string ToString() {
            return "Rarity: " + rarity.ToString();
        }
    }
}
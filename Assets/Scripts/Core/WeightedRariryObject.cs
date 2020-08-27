namespace Core {
    [System.Serializable]
    public class WeightedRarityObject : WeightedValue {
        public RarityObject.Rarity value { get; set; }
        
        public long weight { get; set; }

        public long getWeight() {
            return this.weight;
        }
    }
}

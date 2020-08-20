namespace Core {
    [System.Serializable]
    public class WeightedBool : WeightedValue {
        public bool value { get; set; }
        
        public long weight { get; set; }

        public long getWeight() {
            return this.weight;
        }
    }
}

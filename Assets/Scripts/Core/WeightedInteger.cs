namespace Core {
    [System.Serializable]
    public class WeightedInteger: WeightedValue {
        public int value { get; set; }
        
        public long weight { get; set; }

        public long getWeight() {
            return this.weight;
        }
    }
}

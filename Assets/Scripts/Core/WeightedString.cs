namespace Core {
    [System.Serializable]
    public class WeightedString : WeightedValue {
        public string value { get; set; }
        
        public long weight { get; set; }

        public long getWeight() {
            return this.weight;
        }
    }
}

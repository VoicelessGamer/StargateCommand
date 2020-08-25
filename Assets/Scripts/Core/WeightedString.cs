namespace Core {
    [System.Serializable]
    public class WeightedString : WeightedValue {
        public string value { get; set; }
        
        public long weight { get; set; }

        public WeightedString(string value, long weight) {
            this.value = value;
            this.weight = weight;
        }

        public long getWeight() {
            return this.weight;
        }
    }
}

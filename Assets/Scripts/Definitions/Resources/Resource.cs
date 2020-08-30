namespace Definitions.ResourceDefinitions {
    [System.Serializable]
    public class Resource {

        public long amount;
        public long max;
        public float progress;
        public float progressRate;

        public Resource() {
            this.amount = 0;
            this.max = 10;
            this.progress = 0.0f;
            this.progressRate = 0.1f;
        }

        public Resource(long amount, long max, float progress, float progressRate) {
            this.amount = amount;
            this.max = max;
            this.progress = progress;
            this.progressRate = progressRate;
        }
    }
}
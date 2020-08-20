namespace Definitions.Destinations {
    [System.Serializable]
    public class DestinationDefinition {

        public enum EnvironmentState {
            NORMAL,
            TOXIC,
            SCORCHED,
            FROZEN,
            VACUUM
        }
        
        public string designation;

        public EnvironmentState environmentState;

        public DestinationDefinition(string designation, EnvironmentState environmentState) {
            this.designation = designation;
            this.environmentState = environmentState;
        }

        public override string ToString() {
            return "Designation: " + this.designation + ", Environment State: " + this.environmentState.ToString();
        }
    }
}
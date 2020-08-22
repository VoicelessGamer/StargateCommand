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

        public string address;

        public string designation;

        public EnvironmentState environmentState;

        public DestinationDefinition(string address, string designation, EnvironmentState environmentState) {
            this.address = address;
            this.designation = designation;
            this.environmentState = environmentState;
        }

        public override string ToString() {
            return "Address: " + this.address + ", Designation: " + this.designation + ", Environment State: " + this.environmentState.ToString();
        }
    }
}
namespace Definitions.Items {
    [System.Serializable]
    public class ItemDefinition : RarityObject {

        public string name;

        public override string ToString() {
            return base.ToString() + ", Name: " + this.name;
        }

    }
}
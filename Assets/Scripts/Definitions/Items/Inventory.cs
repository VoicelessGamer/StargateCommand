using Definitions.Weapons;
using System.Collections.Generic;

namespace Definitions.Items {
    [System.Serializable]
    public class Inventory {

        public List<WeaponDefinition> primaryWeaponDefinitions;

        public List<WeaponDefinition> secondaryWeaponDefinitions;

        public Inventory() {
            this.primaryWeaponDefinitions = new List<WeaponDefinition>();
            this.secondaryWeaponDefinitions = new List<WeaponDefinition>();
        }

        public Inventory(List<WeaponDefinition> primaryWeaponDefinitions, List<WeaponDefinition> secondaryWeaponDefinitions) {
            this.primaryWeaponDefinitions = primaryWeaponDefinitions;
            this.secondaryWeaponDefinitions = secondaryWeaponDefinitions;
        }
    }
}
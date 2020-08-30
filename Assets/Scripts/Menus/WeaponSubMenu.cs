using Definitions.Items;
using Definitions.Weapons;
using System.Collections.Generic;

namespace Menus {
    public class WeaponSubMenu : ItemSubMenu {

        public void createPanels(List<WeaponDefinition> definitions) {
            foreach(WeaponDefinition def in definitions) {
                addPanel(def.name, def.minimumDamage + " - " + def.maximumDamage);
            }
        }
    }
}
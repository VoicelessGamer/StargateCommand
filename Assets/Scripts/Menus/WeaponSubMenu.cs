using Core;
using Definitions.Items;
using Definitions.Weapons;
using Items;
using System.Collections.Generic;
using UnityEngine;

namespace Menus {
    public class WeaponSubMenu : ItemSubMenu {

        public void createPanels(List<WeaponDefinition> definitions) {
            foreach(WeaponDefinition def in definitions) {
                addPanel(def.name, def.minimumDamage + " - " + def.maximumDamage, ItemUtil.getRarityColour(def.rarity));
            }
        }
    }
}
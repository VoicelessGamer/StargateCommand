using Core;
using Definitions.Items;
using Definitions.Weapons;
using Items;
using UnityEngine;
using Weapons;

namespace Menus {
    public class InventoryMenu : MonoBehaviour {

        public WeaponSubMenu primaryWeaponSubMenu;

        public WeaponSubMenu secondaryWeaponSubMenu;

        private Inventory inventory;

        private void Start() {
            inventory = ItemUtil.getInventory();
            primaryWeaponSubMenu.createPanels(inventory.primaryWeaponDefinitions);
            secondaryWeaponSubMenu.createPanels(inventory.secondaryWeaponDefinitions);
        }

        public void addPrimaryWeapon() {
            WeaponDefinition weapon;
                
            int i = (int)Mathf.Round(Random.Range(0, 4));

            switch(i) {
                case 0:
                    weapon = WeaponUtil.getWeapon("M16A3", RarityObject.Rarity.COMMON);
                    break;
                case 1:
                    weapon = WeaponUtil.getWeapon("M16A3", RarityObject.Rarity.UNCOMMON);
                    break;
                case 2:
                    weapon = WeaponUtil.getWeapon("M16A3", RarityObject.Rarity.RARE);
                    break;
                case 3:
                    weapon = WeaponUtil.getWeapon("M16A3", RarityObject.Rarity.VERY_RARE);
                    break;
                case 4:
                default:
                    weapon = WeaponUtil.getWeapon("M16A3", RarityObject.Rarity.LEGENDARY);
                    break;
            }

            primaryWeaponSubMenu.addPanel(weapon.name, weapon.minimumDamage + " - " + weapon.maximumDamage);

            this.inventory.primaryWeaponDefinitions.Add(weapon);

            ItemUtil.saveInventory(inventory);
        }

        public void addSecondaryWeapon() {
            WeaponDefinition weapon;

            int i = (int)Mathf.Round(Random.Range(0, 4));

            switch (i) {
                case 0:
                    weapon = WeaponUtil.getWeapon("M9A1", RarityObject.Rarity.COMMON);
                    break;
                case 1:
                    weapon = WeaponUtil.getWeapon("M9A1", RarityObject.Rarity.UNCOMMON);
                    break;
                case 2:
                    weapon = WeaponUtil.getWeapon("M9A1", RarityObject.Rarity.RARE);
                    break;
                case 3:
                    weapon = WeaponUtil.getWeapon("M9A1", RarityObject.Rarity.VERY_RARE);
                    break;
                case 4:
                default:
                    weapon = WeaponUtil.getWeapon("M9A1", RarityObject.Rarity.LEGENDARY);
                    break;
            }

            secondaryWeaponSubMenu.addPanel(weapon.name, weapon.minimumDamage + " - " + weapon.maximumDamage);

            this.inventory.secondaryWeaponDefinitions.Add(weapon);

            ItemUtil.saveInventory(inventory);
        }
    }
}
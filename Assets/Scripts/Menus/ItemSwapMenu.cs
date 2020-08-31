using Definitions.Items;
using Definitions.Weapons;
using Items;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menus {
    public class ItemSwapMenu : MonoBehaviour {

        public Transform itemView;

        public GameObject itemPanel;

        private Action<WeaponDefinition> returnAction;

        private WeaponDefinition chosenDefinition;

        private void setupWeaponMenu(WeaponDefinition currentDefinition) {
            Transform currentItemPanel = transform.Find("CurrentItemPanel");

            //set background colour
            currentItemPanel.Find("Background").GetComponent<Image>().color = ItemUtil.getRarityColour(currentDefinition.rarity);

            //set the name text on the panel
            currentItemPanel.Find("Name").GetComponent<Text>().text = currentDefinition.name;

            //set the name text on the panel
            currentItemPanel.Find("Info").GetComponent<Text>().text = currentDefinition.minimumDamage + " - " + currentDefinition.maximumDamage;
        }

        public void setupWeaponMenu(WeaponDefinition currentDefinition, Action<WeaponDefinition> returnAction) {
            setupWeaponMenu(currentDefinition);
            onItemSelected(currentDefinition);

            this.returnAction = returnAction;
        }

        public void setupPrimaryMenu(WeaponDefinition currentDefinition, Action<WeaponDefinition> returnAction) {
            setupWeaponMenu(currentDefinition, returnAction);

            Inventory inventory = ItemUtil.getInventory();

            setupWeaponDefinitions(inventory.primaryWeaponDefinitions);
        }

        public void setupSecondaryMenu(WeaponDefinition currentDefinition, Action<WeaponDefinition> returnAction) {
            setupWeaponMenu(currentDefinition, returnAction);

            Inventory inventory = ItemUtil.getInventory();

            setupWeaponDefinitions(inventory.secondaryWeaponDefinitions);
        }

        public void setupWeaponDefinitions(List<WeaponDefinition> weaponDefinitions) {
            foreach (WeaponDefinition def in weaponDefinitions) {
                //instantiating the new item panel and adding to the view
                Transform item = Instantiate(itemPanel, Vector3.zero, Quaternion.identity).transform;
                item.SetParent(itemView, false);

                //setting the icon image on the panel
                //item.Find("icon").GetComponent<Image>().sprite = icon;

                //set background colour
                item.Find("Background").GetComponent<Image>().color = ItemUtil.getRarityColour(def.rarity);

                //set the name text on the panel
                item.Find("Name").GetComponent<Text>().text = def.name;

                //set the name text on the panel
                item.Find("Info").GetComponent<Text>().text = def.minimumDamage + " - " + def.maximumDamage;

                item.Find("SelectBtn").GetComponent<Button>().onClick.AddListener(() => { onItemSelected(def); });
            }
        }

        public void onItemSelected(WeaponDefinition currentDefinition) {
            Transform replaceItemPanel = transform.Find("ReplaceItemPanel");

            //set background colour
            replaceItemPanel.Find("Background").GetComponent<Image>().color = ItemUtil.getRarityColour(currentDefinition.rarity);

            //set the name text on the panel
            replaceItemPanel.Find("Name").GetComponent<Text>().text = currentDefinition.name;

            //set the name text on the panel
            replaceItemPanel.Find("Info").GetComponent<Text>().text = currentDefinition.minimumDamage + " - " + currentDefinition.maximumDamage;

            chosenDefinition = currentDefinition;
        }

        public void onSwap() {
            returnAction(chosenDefinition);
        }
    }
}
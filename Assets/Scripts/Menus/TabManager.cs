using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menus {
    public class TabManager : MonoBehaviour {
        public List<GameObject> tabPanels;
        public List<Button> tabButtons;

        private int activeTab = 0;

        void Awake() {
            //set an on click event for each button
            for(int i = 0; i < tabButtons.Count; i++) {
                int index = i;
                tabButtons[i].onClick.AddListener(() => { changeTab(index); });
            }
            //show the current active tab
            showTab(activeTab);
        }

        public void changeTab(int index) {
            //hide the current active tab
            hideTab(activeTab);
            //show the desired tab if the index is in bounds
            if (index >= 0) {
                showTab(index);
            }
            //update the active tab index
            activeTab = index;
        }

        private void hideTab(int index) {
            //hide the tab panel
            tabPanels[index].SetActive(false);
            //set the matching button to interactable so can be accessed again
            tabButtons[index].interactable = true;
        }

        private void showTab(int index) {
            //show the tab panel
            tabPanels[index].SetActive(true);
            //set the matching button to not interactable
            tabButtons[index].interactable = false;
        }
    }
}
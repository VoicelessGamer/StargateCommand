using System.Collections.Generic;
using UnityEngine;

namespace Menus {
    public class TabManager : MonoBehaviour {
        public List<GameObject> tabPanels;

        private int activeTab = 0;

        public void changeTab(int index) {
            hideTab(activeTab);
            showTab(index);
            activeTab = index;
        }

        private void hideTab(int index) {
            tabPanels[index].SetActive(false);
        }

        private void showTab(int index) {
            tabPanels[index].SetActive(true);
        }
    }
}
using UnityEngine;

namespace Menus {
    public class GameMenuManager : MonoBehaviour {

        public TabManager menuView;

        public void toggleMenuView() {
            menuView.gameObject.SetActive(!menuView.gameObject.activeSelf);
        }
    }
}
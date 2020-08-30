using UnityEngine;
using UnityEngine.UI;

namespace Menus {
    public class ItemSubMenu : MonoBehaviour {

        public Transform itemView;

        public GameObject itemPanel;

        //public void addPanel(Sprite icon, string name, string info) {
        public void addPanel(string name, string info) {
            //instantiating the new item panel and adding to the view
            Transform item = Instantiate(itemPanel, Vector3.zero, Quaternion.identity).transform;
            item.SetParent(itemView, false);

            //setting the icon image on the panel
            //item.Find("icon").GetComponent<Image>().sprite = icon;

            //set the name text on the panel
            item.Find("Name").GetComponent<Text>().text = name;

            //set the name text on the panel
            item.Find("Info").GetComponent<Text>().text = info;
        }
    }
}
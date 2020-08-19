using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missions.Address {
    public class Keyboard : MonoBehaviour {
        private List<GameObject> glyphKeys;

        private string keyTag = "KeyboardGlyph";

        void Start() {
            glyphKeys = new List<GameObject>();
            //search through all children and stores all gameobjects with the correct tag
            foreach (Transform t in this.transform) {
                if (t.gameObject.tag == keyTag) {
                    glyphKeys.Add(t.gameObject);
                }
            }
        }

        public void unlockAllGlyphs() {
            foreach (GameObject go in glyphKeys) {
                go.GetComponent<Button>().interactable = true;
            }
        }

        public void lockAllGlyphs() {
            foreach (GameObject go in glyphKeys) {
                go.GetComponent<Button>().interactable = false;
            }
        }
        public void unlockGlyph(int index) {
            if (index >= 0 && index < glyphKeys.Count) {
                glyphKeys[index].GetComponent<Button>().interactable = true;
            }
        }

        public void lockGlyph(int index) {
            if (index >= 0 && index < glyphKeys.Count) {
                glyphKeys[index].GetComponent<Button>().interactable = false;
            }
        }
    }
}
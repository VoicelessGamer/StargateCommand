using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour {
    private List<GameObject> glyphKeys;

    // Start is called before the first frame update
    void Start() {
        glyphKeys = new List<GameObject>();
        foreach (Transform t in this.transform) {
            if(t.gameObject.tag == "KeyboardGlyph") {
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
        if(index >= 0 && index < glyphKeys.Count) {
            glyphKeys[index].GetComponent<Button>().interactable = true;
        }
    }

    public void lockGlyph(int index) {
        if (index >= 0 && index < glyphKeys.Count) {
            glyphKeys[index].GetComponent<Button>().interactable = false;
        }
    }
}

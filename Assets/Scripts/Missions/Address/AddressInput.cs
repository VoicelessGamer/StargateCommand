﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddressInput : MonoBehaviour {

    public Keyboard keyboard;

    public List<Sprite> symbolSprites;

    public List<Button> inputChevrons;

    private int activeSelection;

    private int maxAddressSymbols = 7;

    private int[] address;

    private int originSymbolIndex = 0;

    // Start is called before the first frame update
    void Start() {
        address = new int[maxAddressSymbols];
        clearAddress();
    }

    public void inputSymbol(int symbolIndex) {
        inputChevrons[activeSelection].image.sprite = symbolSprites[symbolIndex];
        inputChevrons[activeSelection].image.enabled = true;

        if(address[activeSelection] != -1) {
            keyboard.unlockGlyph(address[activeSelection]);
        }

        address[activeSelection] = symbolIndex;
        keyboard.lockGlyph(address[activeSelection]);

        if (activeSelection < (maxAddressSymbols - 1)) {
            activeSelection++;
        }
    }

    public void setActiveSelection(int index) {
        activeSelection = index;
        Debug.Log("Index set: " + index);
    }

    public void clearAddress() {
        activeSelection = 0;
        for (int i = 0; i < address.Length; i++) {
            if(address[i] != -1) {
                keyboard.unlockGlyph(address[i]);
                address[i] = -1;
            }

            inputChevrons[i].image.enabled = false;
        }
    }

    public int[] retrieveAddress() {
        if(validateAddress()) {
            return address;
        }
        return null;
    }

    public bool validateAddress() {
        for (int i = 0; i < address.Length; i++) {
            if (address[i] == -1) {
                return false;
            }

            if(i == address.Length - 1 && address[i] != originSymbolIndex) {
                return false;
            }
        }

        return true;
    }
}
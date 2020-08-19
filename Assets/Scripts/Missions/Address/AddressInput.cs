using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missions.Address {
    public class AddressInput : MonoBehaviour {

        //the keyboard object which controls the on-screen keys
        public Keyboard keyboard;

        //list of the sprite images in index order to add to the chevron positions
        public List<Sprite> symbolSprites;

        //list of the chevron buttons which show the player's selection
        public List<Button> inputChevrons;

        //the current selected symbol position
        private int activeSelection;

        //max number of address symbol to be input (need to think about 8 symbol addresses)
        private int maxAddressSymbols = 7;

        //the address as index numbers
        private int[] address;

        // Start is called before the first frame update
        void Start() {
            //initialise the address array
            address = new int[maxAddressSymbols];
            clearAddress();
        }

        //called when a button on the glyph keyboard is interacted with
        public void inputSymbol(int symbolIndex) {
            //set the active chevron button's sprite to the matching symbol index
            inputChevrons[activeSelection].image.sprite = symbolSprites[symbolIndex];

            //enable the chevron button so that player can change the current active selection index
            inputChevrons[activeSelection].image.enabled = true;

            //check if the position had not yet been updated with a symbol
            if (address[activeSelection] != -1) {
                //unlock the previous key on the glyph keyboard
                keyboard.unlockGlyph(address[activeSelection]);
            }

            //set the symbol index in the address array
            address[activeSelection] = symbolIndex;

            //lock the recently selected keyboard key
            keyboard.lockGlyph(address[activeSelection]);

            //update the active selection index to the next position in the address array, providing there is a next position in the array
            if (activeSelection < (maxAddressSymbols - 1)) {
                activeSelection++;
            }
        }

        public void setActiveSelection(int index) {
            //sets the current active selection index to the passed in index parameter
            activeSelection = index;
        }

        public void clearAddress() {
            //reset the active selection index to the first position
            activeSelection = 0;
            for (int i = 0; i < address.Length; i++) {
                //unlock each selected keyboard key and reset the address symbol
                if (address[i] != -1) {
                    keyboard.unlockGlyph(address[i]);
                    address[i] = -1;
                }

                // disable each position in the chevron button array
                inputChevrons[i].image.enabled = false;
            }
        }

        public int[] getAddress() {
            return address;
        }
    }
}
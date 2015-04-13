using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OmeletteKeyComboInputController : MinigameInputController {
	private KeyCombo scoopAndFlip;
	private KeyValuePair<string, int> lastInput;
	private string lastKeyPressed;

	void Start () {
		scoopAndFlip = new KeyCombo ();
		lastKeyPressed = "";
	}

	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			if(Input.inputString != "") {
				
			}
		}
	}
	class KeyCombo {
		KeyValuePair<string, int>[] combo;
		public KeyCombo () {

		}
	};
}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private string _Class;
	public string Class { 
		get {
			if(_Class != PlayerPrefs.GetString ("Class"))
				_Class = PlayerPrefs.GetString ("Class");
			return _Class;
		}
	}

	// Should maybe be split into PlayerController and PlayerInput

	public float maxSpeed = 10f;

	private bool isInStation = false;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Interact")) {
			if (isInStation) {
				isInStation = false;
			}
			// else if we're colliding with the
			// trigger box of a station,
			// we are in a station, so set that to true
		}
		if (Input.GetButtonUp ("Menu")) {
			//TODO: Fill in menu stuff
		}
		//TODO: Recipe overlay
	}
	
	void FixedUpdate() {
		/* Ignore movement controls if in station */
		if (!isInStation) { 
			float mx = Input.GetAxis ("Horizontal");
			float my = Input.GetAxis ("Vertical");
			
			GetComponent<Rigidbody2D>().velocity = new Vector2 (mx * maxSpeed, my * maxSpeed);
		}
	}
}

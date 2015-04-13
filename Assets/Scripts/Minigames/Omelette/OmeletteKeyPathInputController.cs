using UnityEngine;
using System.Collections;

public class OmeletteKeyPathInputController : MinigameInputController {

	private float remainingDistanceToPan;
	private float remainingDistanceToFlipHeight;
	private float remainingDistanceToFlip;

	public float distanceToPan;
	public float distanceToFlipHeight;
	public float distanceToFlip;

	public int speed;

	[System.NonSerialized]
	public bool isBeingFlipped = false;

	void Update () {
		if (remainingDistanceToFlipHeight == distanceToFlipHeight
			&& remainingDistanceToFlip == distanceToFlip) {

			if (Input.GetAxis ("Horizontal") < 0
				&& remainingDistanceToPan > 0) {
				remainingDistanceToPan -= (float)speed * Time.deltaTime;
				if (remainingDistanceToPan < 0)
					remainingDistanceToPan = 0;
			} else if (Input.GetAxis ("Horizontal") > 0
				&& remainingDistanceToPan < distanceToPan) {
				remainingDistanceToPan += (float)speed * Time.deltaTime;
				if (remainingDistanceToPan > distanceToPan)
					remainingDistanceToPan = distanceToPan;
			}

		} else if (remainingDistanceToPan == 0
			&& remainingDistanceToFlip == distanceToFlip
			// final condition to allow the user to progress to flipping
			&& remainingDistanceToFlipHeight > 0) {  

			if (Input.GetAxis ("Vertical") < 0
				&& remainingDistanceToFlipHeight > 0) {
				remainingDistanceToFlipHeight -= (float)speed * Time.deltaTime;
				if (remainingDistanceToFlipHeight < 0)
					remainingDistanceToFlipHeight = 0;
			} else if (Input.GetAxis ("Vertical") > 0
				&& remainingDistanceToFlipHeight < distanceToFlipHeight) {
				remainingDistanceToFlipHeight += (float)speed * Time.deltaTime;
				if (remainingDistanceToFlipHeight > distanceToFlipHeight)
					remainingDistanceToFlipHeight = distanceToFlipHeight;
			}

		} else if (remainingDistanceToPan == 0
			&& remainingDistanceToFlipHeight == 0) {

			if (Input.GetAxis ("Vertical") < 0
			    && remainingDistanceToFlip > 0) {
				remainingDistanceToFlip -= (float)speed * Time.deltaTime;
				if (remainingDistanceToFlip < 0)
					remainingDistanceToFlip = 0;
			} else if (Input.GetAxis ("Vertical") > 0
			           && remainingDistanceToFlip < distanceToFlip) {
				remainingDistanceToFlip += (float)speed * Time.deltaTime;
				if (remainingDistanceToFlip > distanceToFlip)
					remainingDistanceToFlip = distanceToFlip;
			}

		}

		if (remainingDistanceToFlip == 0)
			isBeingFlipped = true;
	}
}

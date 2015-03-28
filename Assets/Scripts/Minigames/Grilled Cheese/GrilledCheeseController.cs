using UnityEngine;
using System.Collections;

public class GrilledCheeseController : MinigameController {

	#region Interal members
	private bool hasFlipped = false;
	private bool hasRemoved = false;
	#endregion

	#region Interface implementation
	public override int GetScore () {
		return score;
	}
	public override State GetState () {
		return state;
	}

	protected override bool ShouldScore () {
		return hasFlipped || hasRemoved;
	}

	protected override int GetScoreToEarn () {
		int scoreToEarn = 0;
		if (hasFlipped)
			scoreToEarn += GetScoreToEarnFromFlipping ();
		if (hasRemoved)
			scoreToEarn += GetScoreToEarnFromRemoving ();
		hasFlipped = hasRemoved = false;
		return scoreToEarn;
	}

	protected override State DetermineState () {
		throw new System.NotImplementedException ();
	}
	#endregion

	#region Internal methods
	private int GetScoreToEarnFromFlipping() {
		throw new System.NotImplementedException();
	}
	private int GetScoreToEarnFromRemoving() {
		throw new System.NotImplementedException();
	}
	#endregion
}

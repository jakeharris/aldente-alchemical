using UnityEngine;
using System.Collections;

public class OmeletteController : MinigameController {

	#region Sneaky secret variables
	private bool hasBeenCompleted = false;
	private bool isBeingPoured = false;
	private bool hasBeenPoured = false;
	private float topCooked = 0f; // increments over time while we cook it
	private float bottomCooked = 0f;
	private bool hasTopBeenCooked = false;
	private bool hasTopBeenScored = false;
	private bool hasBottomBeenCooked = false;
	private bool hasBottomBeenScored = false;
	private bool isBeingFlipped = false;
	private bool hasCompletionBeenScored = false;

	private int flipCount = 0;
	private int topCookedScoredPercentage = 0;
	private int bottomCookedScoredPercentage = 0;
	private bool isTopCooking = false;
	#endregion

	#region Editor-enabled variables
	public float amountToCookSide;
	public int baseScoreForCompletion = 50;
	public int baseScoreForFlipping = 30;
	#endregion

	#region Interface implementation - MinigameController
	public override int GetScore ()
	{
		return score;
	}

	public override State GetState ()
	{
		return state;
	}

	protected override bool ShouldScore ()
	{
		if (input is OmeletteKeyPathInputController && ((OmeletteKeyPathInputController)input).isBeingFlipped) {
            ((OmeletteKeyPathInputController)input).isBeingFlipped = false;
			isBeingFlipped = true;
		}
		return (isBeingFlipped)
			|| (hasTopBeenCooked && hasBottomBeenCooked && hasCompletionBeenScored);
	}

	protected override int GetScoreToEarn ()
	{
		// We want to reward:
		// * Few flips
		// * Handling it just as it becomes time

		// We want to punish:
		// * Taking a pretty long time to handle a side
		if (hasCompletionBeenScored) {
			// Two flips is perfect. One flip or less is impossible.
			// Four flips will be our arbitrary standard.
			// More than four flips deserves to be docked.
			if(flipCount < 2 || flipCount > 4) return 0;
			else return (5 - flipCount) * baseScoreForCompletion;
		} else {
			// This must be a flip, so let's score based on
			// percentage completion

			// Grab the amount of cooked the current side is
			// God the grammar for this is so dumb
			float sideCooked = 
				(isTopCooking ? topCooked : bottomCooked);
			// Determine the percentage completion that that amount is
			int sideCookedCompletionPercentage = (int)((float)(sideCooked / amountToCookSide) * 100);
			// Grab the percentage
			int previouslyCookedCompletionPercentage =
				(isTopCooking ? topCookedScoredPercentage : bottomCookedScoredPercentage);
			int percentageToScore = 
				(sideCookedCompletionPercentage <= 100 ? sideCookedCompletionPercentage : 100)
					- previouslyCookedCompletionPercentage;

			// Upkeep
			if(isTopCooking) 
				topCookedScoredPercentage = sideCookedCompletionPercentage;
			else
				bottomCookedScoredPercentage = sideCookedCompletionPercentage;

			return (int)((float)(percentageToScore * baseScoreForCompletion) / 100);
		}
	}

	protected override State DetermineState ()
	{
		if (!hasBeenCompleted && !hasBeenPoured)
			return State.WaitingToStart;
		else if (isBeingPoured) 
			return State.Starting;
		else if (hasBeenPoured) 
			return State.Active;
		else if (topCooked >= amountToCookSide * 0.5
			|| bottomCooked >= amountToCookSide * 0.5)
			return State.BakerVisible;
		else if (topCooked >= amountToCookSide * 0.75
			|| bottomCooked >= amountToCookSide * 0.75)
			return State.BecomingUrgent;
		else if (topCooked >= amountToCookSide
			|| bottomCooked >= amountToCookSide) 
			return State.Urgent;
		else if (isBeingFlipped)
			return State.Handling;
		else if (hasTopBeenCooked && hasBottomBeenCooked && isBeingFlipped)
			return State.Completing;
		else
			return State.Inactive;
	}
	#endregion
	
}

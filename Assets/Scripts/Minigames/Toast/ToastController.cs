using UnityEngine;
using System.Collections;

public class ToastController : MinigameController {
	public int retrievedAmount; // Amount to score when you retrieve the toast

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
		return timer >= timeToCompletion;
	}
	protected override int GetScoreToEarn ()
	{
		// For toast, we don't want to arbitrarily punish
		// the player for missing it. You just get a flat
		// amount for grabbing it.
		return retrievedAmount;
	}
	protected override State DetermineState ()
	{
		//TODO: Fill this out
		if (timer <= timeToCompletion) 
			return State.Active;
		else
			return State.Urgent;
	}
}

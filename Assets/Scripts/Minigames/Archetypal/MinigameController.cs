using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GameBoardController))]
[RequireComponent(typeof(MinigameInputController))]
[RequireComponent(typeof(Station))]
[SerializeField]
public abstract class MinigameController : MonoBehaviour {
	
	public abstract int GetScore();
	public abstract State GetState();
	
	protected abstract bool ShouldScore();
	protected abstract int GetScoreToEarn();
	protected abstract State DetermineState();

	private State state;
	private int score;

	private MinigameInputController input;

	void Update() {
		state = DetermineState ();
		if (ShouldScore ()) {
			score += GetScoreToEarn();
		}
	}
}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GameBoardController))]
[SerializeField]
public abstract class MinigameController : MonoBehaviour {
	
	public abstract int GetScore();
	public abstract State GetState();
	
	protected abstract bool ShouldScore();
	protected abstract int GetScoreToEarn();
	protected abstract State DetermineState();

	protected State state = State.Inactive;
	protected int score = 0;
	protected float timer = 0f;
	protected float timeToCompletion;

	public MinigameInputController input;

	void Update() {
		timer += Time.deltaTime;
		state = DetermineState ();
		if (ShouldScore ()) {
			score += GetScoreToEarn();
		}
	}

	[System.Serializable]
	public class Timing {
		public float averageTimeToCompletion;
		public float standardDeviation;
	}

	public Timing timing = new Timing();

	void Start () {
		int r = (int)((float)(100*Random.value) + 1);
		int deviationFactor = 0;
		
		if (r <= 68)
			deviationFactor = 1;
		else if (r <= 95)
			deviationFactor = 2;
		else
			deviationFactor = 3;
		
		r = (int)((float)(100*Random.value) + 1);
		if (r > 50) 
			deviationFactor *= -1;
		
		timeToCompletion = timing.averageTimeToCompletion + (timing.standardDeviation * (deviationFactor - 1)) + (timing.standardDeviation * deviationFactor);
	}
}

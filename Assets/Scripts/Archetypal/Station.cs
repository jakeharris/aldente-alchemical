using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(MinigameController))]
public class Station : MonoBehaviour {

	public Sprite sprite;
	public Sprite indicatorSprite;
	public Animation indicatingAnimation;

	private Animator anim;
	private GameObject player;
	private MinigameController minigame;
	private SpriteRenderer render;

	void Start () {
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		minigame = GetComponent<MinigameController> ();
		render = GetComponent<SpriteRenderer> ();
	}

	void Update () {
		// These should be implemented in the animator, not here
		//if (player.GetComponent<PlayerController>().Class == "Baker" && minigame.GetState () == State.BakerVisible) {
			//throw new System.NotImplementedException ();
		//}
		//else if (minigame.GetState () == State.BecomingUrgent) {
			//throw new System.NotImplementedException ();
		//}
		//else if (minigame.GetState () == State.Urgent) {
			//throw new System.NotImplementedException ();
		//}
	}
}

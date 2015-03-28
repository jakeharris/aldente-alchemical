using UnityEngine;
using System.Collections;

public abstract class GameBoardController : MonoBehaviour {

	private Transform GameBoard;

	void Start () {
		GameBoard = gameObject.GetComponentInChildren<Transform> ();
	}

	public void ToggleBoard() {
		GameBoard.position = new Vector2 (GameBoard.position.x, -50);
	}
}

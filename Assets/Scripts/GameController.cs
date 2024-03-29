﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public List<MinigameController> minigames;
	
	public TextMesh scoreText;
	public TextMesh timerText;

	public float timeLimit;

	private int score;
	private float timer;
	
	// Update is called once per frame
	void Update () {
		score = 0;
		foreach (MinigameController c in minigames) 
			score += c.GetScore ();

		timer += Time.deltaTime;
		if (timer >= timeLimit) {
			Application.Quit();
		}

		scoreText.text = "Score:\n" + score;
		timerText.text = "Time remaining:\n" + (timeLimit - timer);
	}
}

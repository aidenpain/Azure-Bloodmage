using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameOver : MonoBehaviour {
	public GameObject gameOverCanvas;
	private int score;
	
	public void gameOver(){
		gameObject.GetComponent<ABMPlayerController>().enabled = false;
		
		gameOverCanvas.SetActive(true);
		score = gameObject.GetComponent<LocalScoreTracker>().GetLocalScore();
		ScoreTracker.Instance.SetHighScore(score);
		Time.timeScale = 0f;
	}
}



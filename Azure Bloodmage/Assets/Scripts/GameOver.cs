using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameOver : MonoBehaviour {
	public GameObject gameOverCanvas;
	
	private GameObject player;
	private int score;
	
	void Start(){
		player = GameObject.Find("Player");
	}
	void Update()
	{
		
	}
	
	public void gameOver(){
		gameOverCanvas.SetActive(true);
		score = player.GetComponent<CollectObjects>().localScore;
		ScoreTracker.Instance.SetHighScore(score);
		Time.timeScale = 0f;
	}
}



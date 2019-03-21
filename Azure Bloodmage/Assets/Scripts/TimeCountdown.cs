using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class TimeCountdown : MonoBehaviour {
	public GameObject gameOverCanvas;
	public float timeStart = 10.0f;
	public float timeLeft;
	
	public GameObject ui;
	public GameObject eventsys;
	
	private GameObject player;
	private int score;
	private bool gameOver;
	private int thisSceneIndex;
	private static int MAX_SCENE_NO = 3;
	
	void Start(){
		player = GameObject.Find("Player");
		gameOver = false;
		thisSceneIndex = 2;
	}
	void OnEnable(){
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	void OnDisable(){
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
	void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		timeLeft = timeStart;
	}
	
	void Update()
	{
		timeLeft -= Time.deltaTime;
		
		if(timeLeft > 0){gameObject.GetComponent<Text>().text = "Time: " + Mathf.Floor(timeLeft);}
		if(timeLeft < 0)
		{
			if(gameOver == false){
				thisSceneIndex++;
				Debug.Log(thisSceneIndex);
				if(thisSceneIndex <= MAX_SCENE_NO){
					SceneManager.LoadScene(thisSceneIndex);
				}
				else{
					gameOver = true;
					score = player.GetComponent<CollectObjects>().localScore;
					ScoreTracker.Instance.SetHighScore(score);
					Time.timeScale = 0f;
					gameOverCanvas.SetActive(true);
				}
			}
		}	
	}
}



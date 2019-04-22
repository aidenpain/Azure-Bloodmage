using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour{
	public List<int> scoreList;
	private int localScore;
	private Text scoreText;
	
	public static ScoreTracker Instance {get; private set;}
	
	void Start(){
		localScore = 0;
	}
	
	void Awake(){
		DontDestroyOnLoad(gameObject);
		scoreList = new List<int>(10);
		
		for(int i = 0; i < 10; i++){
			scoreList.Add(0);
		}
		
		if (Instance == null) { Instance = this; }
	}
	
	void OnEnable(){
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}
	
	void OnDisable(){
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}
	
	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode){
		scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
		scoreText.text = "Score: "+ localScore;
	}
	
	public void IncreaseLocalScore(int i){
		localScore += i;
		scoreText.text = "Score: "+ localScore;
	}
	
	public void SetHighScore(int score){
		for(int i = 0; i < 10; i++){
			if(score > scoreList[i]){
				scoreList.RemoveAt(9);
				scoreList.Insert(i, score);
				break;
			}
		}
	}
	
	public int GetLocalScore(){
		return localScore;
	}
}
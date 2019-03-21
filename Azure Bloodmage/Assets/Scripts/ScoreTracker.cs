using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour{
	public List<int> scoreList;
	
	public static ScoreTracker Instance {get; private set;}
	
	void Awake(){
		DontDestroyOnLoad(gameObject);
		
		scoreList = new List<int>(10);
		
		for(int i = 0; i < 10; i++){
			scoreList.Add(0);
		}
		
		if (Instance == null) { Instance = this; }
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
}
using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LocalScoreTracker : MonoBehaviour{
	private int localScore;
	public Text scoreText;
	
	void Start(){
		localScore = 0;
	}
	
	public void IncreaseLocalScore(int i){
		localScore += i;
		scoreText.text = "Score: "+ localScore;
	}
	
	public int GetLocalScore(){
		return localScore;
	}
}
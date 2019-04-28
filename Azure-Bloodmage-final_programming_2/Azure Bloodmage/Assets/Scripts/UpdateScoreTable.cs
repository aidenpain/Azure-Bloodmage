using System;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreTable : MonoBehaviour{
	private string scores;

	void Awake(){
		scores = "";
/*		for(int i = 0; i < 10; i++){
			scores += ((i+1) + ": " + ScoreTracker.Instance.scoreArray[i] + "\n");
		}*/
		for(int i = 0; i < 10; i++){
			scores += ((i+1) + ": " + ScoreTracker.Instance.scoreList[i] + "\n");
		}
		gameObject.GetComponent<Text>().text = scores;
	}
}
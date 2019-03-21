using System;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHighScore : MonoBehaviour{
	void Awake(){
		gameObject.GetComponent<Text>().text = "High Score: " + ScoreTracker.Instance.scoreList;
	}
}
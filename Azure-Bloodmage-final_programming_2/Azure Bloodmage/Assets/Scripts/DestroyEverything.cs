using System;
using UnityEngine;

public class DestroyThings : MonoBehaviour{
	
	private GameObject scoreTracker;

	void Start(){
		scoreTracker = GameObject.Find("LocalScoreTracker");
	}

	public void DestroyTheThing(){
		Destroy(scoreTracker);
	}
}
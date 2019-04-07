using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinPickup : MonoBehaviour{
	public GameObject player;
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject == player){
			player.GetComponent<LocalScoreTracker>().IncreaseLocalScore(1);
			Destroy(gameObject);
		}
	}
	
}
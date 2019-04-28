using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinPickup : MonoBehaviour{
	private GameObject player;
	private GameObject scoreTracker;
	
	void Start(){
	}
	
	void OnEnable(){
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}
	
	void OnDisable(){
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}
	
	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode){
		player = GameObject.Find("Player");
		scoreTracker = GameObject.Find("ScoreTracker");
	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject == player){
			scoreTracker.GetComponent<ScoreTracker>().IncreaseLocalScore(100);
			player.GetComponent<CoinTracker>().IncreaseNumCoins(1);
			Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("Coin");
        }
	}
	
}

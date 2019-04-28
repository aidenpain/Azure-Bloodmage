using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour {
	public GameObject levelFinishScreen;
	public int coinsNeeded;
	
	void Start(){
		
	}
	
	void OnTriggerEnter (Collider col)
	{
		//reaching the exit
		if(col.gameObject.name == "Exit"){
			//if you got the coins, complete the level
			if(gameObject.GetComponent<CoinTracker>().GetNumCoins() >= coinsNeeded){
				levelFinishScreen.SetActive(true);
				GetComponent<ABMPlayerController>().enabled = false;
				GetComponent<Attack>().enabled = false;
			}
			//otherwise show the prompt
			else{
				StartCoroutine(col.gameObject.GetComponent<ShowDialogue>().showText());
			}
		}
	}
}

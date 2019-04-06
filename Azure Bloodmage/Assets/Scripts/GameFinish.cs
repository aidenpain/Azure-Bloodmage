	using System;
using UnityEngine;
using UnityEngine.UI;

public class GameFinish : MonoBehaviour {
	public GameObject levelFinishScreen;
	
	void OnTriggerEnter (Collider col)
	{
		//reaching the cave
		if(col.gameObject.name == "CaveEntrance" || col.gameObject.name == "CaveEntrance2"){
			//if you got the coins, complete the game
			if(GetComponent<CollectObjects>().localScore >= 2){
				levelFinishScreen.SetActive(true);
				GetComponent<ABMPlayerController>().enabled = false;
			}
			//otherwise show the prompt
			else{
				StartCoroutine(col.gameObject.GetComponent<ShowDialogue>().showText());
			}
		}
	}
}

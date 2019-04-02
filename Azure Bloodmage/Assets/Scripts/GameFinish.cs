	using System;
using UnityEngine;
using UnityEngine.UI;

public class GameFinish : MonoBehaviour {
	public GameObject levelFinishScreen;
	private bool gotCoins;
	
	void Start(){
		gotCoins = false;
	}
	
	void OnTriggerEnter (Collider col)
	{
		//getting both coins
		if(GetComponent<CollectObjects>().localScore == 2)
		{
			gotCoins = true;
		}
		//reaching the mousehole
		else if(col.gameObject.name == "CaveEntrance")
		{
			//if you got the coins, complete the game
			if(gotCoins){
				levelFinishScreen.SetActive(true);
				GetComponent<ABMPlayerController>().enabled = false;
			}
		}
	}
}

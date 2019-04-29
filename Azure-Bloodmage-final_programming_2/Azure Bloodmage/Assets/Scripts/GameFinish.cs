using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour {
	public GameObject levelFinishScreen;
	public GameObject boss;
	
	void Start(){
		
	}
	
	void Update ()
	{
		//if you beat the boss
		if(boss == null){
			levelFinishScreen.SetActive(true);
			GetComponent<ABMPlayerController>().enabled = false;
			GetComponent<Attack>().enabled = false;
		}
	}
}

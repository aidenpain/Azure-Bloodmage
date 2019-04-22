using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class Pause : MonoBehaviour {
		public GameObject pauseScreen;
		public GameObject gameOverGameObject;
		public GameObject levelFinishGameObject;
		
		void Awake(){
			
		}
		
		void Start(){
		}
		
		void Update(){
			if(Input.GetButtonDown("Pause") && !(gameOverGameObject.activeSelf) && !(levelFinishGameObject.activeSelf)){
				PauseUnpause();
			}
		}
		
		public void PauseUnpause(){
			if(Time.timeScale == 1.0f){
				Time.timeScale = 0.0f;
				pauseScreen.gameObject.SetActive(true);
				gameObject.GetComponent<ABMPlayerController>().enabled = false;
				gameObject.GetComponent<Attack>().enabled = false;
			}
			else{
				Time.timeScale = 1.0f;
				pauseScreen.gameObject.SetActive(false);
				gameObject.GetComponent<ABMPlayerController>().enabled = true;
				gameObject.GetComponent<Attack>().enabled = true;
			}
		}
	}
}
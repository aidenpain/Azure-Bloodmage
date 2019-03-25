using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class GameFinish : MonoBehaviour {
		public Canvas levelFinishScreen;
		public GameObject cheese;
		private bool cheeseGet;
		public GameObject cheesePromptText;
		public GameObject cheeseGetText;
		public GameObject cheeseGetImg;
		public GameObject mousehole;
		public AudioSource BGMusic;
		
		void Start(){
			cheeseGet = false;
		}
		
		void OnTriggerEnter (Collider col)
		{
			//getting the cheese and opening the mousehole
			if(col.gameObject == cheese)
			{
				Destroy(col.gameObject);
				
				cheeseGetText.gameObject.SetActive(true);
				cheeseGetImg.gameObject.SetActive(true);
				cheeseGet = true;
			}
			//reaching the mousehole
			else if(col.gameObject == mousehole)
			{
				//if you got the cheese, complete the game
				if(cheeseGet){
					BGMusic.mute = true;
					levelFinishScreen.gameObject.SetActive(true);
					GetComponent<RigidbodyFirstPersonController>().enabled = false;
				}
				//else prompt the user to find the cheese
				else{
					cheesePromptText.gameObject.SetActive(true);
				}
			}
		}
	}
}
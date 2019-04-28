using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowDialogueAndSelfdestruct : MonoBehaviour {
	public List<string> dialogueList;
	public GameObject panel;
	public Text panelText;
	private int listLength;
	
	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.name == "Player"){
			StartCoroutine(showText());
		}
	}
	
	public IEnumerator showText(){
		panel.SetActive(true);
		Time.timeScale = 0.0f;
		int i = 1;
		panelText.text = dialogueList[0];
		listLength = dialogueList.Count;
		while(i < listLength + 1){
			if(Input.GetButtonDown("Fire1")){
				if(i < listLength){
					panelText.text = dialogueList[i];
					i++;
				}
				else{	//if we've reached the end of the list, destroy the object
					panel.SetActive(false);
					Time.timeScale = 1.0f;
					Destroy(gameObject);
					yield break;
				}
			}
			yield return null;
		}
	}
}
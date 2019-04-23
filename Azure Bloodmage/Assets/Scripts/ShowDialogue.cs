using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowDialogue : MonoBehaviour {
	public List<string> dialogueList;
	public GameObject panel;
	public Text panelText;
	private int listLength;
	
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
				else{	//if we've reached the end of the list, close the panel
					panel.SetActive(false);
					Time.timeScale = 1.0f;
					yield break;
				}
			}
			yield return null;
		}
	}
}
using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof (Rigidbody))]
[RequireComponent(typeof (CapsuleCollider))]
public class CollectObjects : MonoBehaviour{
	public int localScore;
	public Text scoreText;
	
	void Start(){
		localScore = 0;
	}
	
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Collectible"){
			Destroy(col.gameObject);
			UpdateLocalScore(1);
		}
		/*else if(col.gameObject.tag == "Interactable"){
			if(col.gameObject.GetComponent<ShowDialogue>())
				StartCoroutine(col.gameObject.GetComponent<ShowDialogue>().showText());
		}*/
	}
	
	void UpdateLocalScore(int score){
		localScore += score;
		scoreText.text = "Score: "+ localScore;
	}
}
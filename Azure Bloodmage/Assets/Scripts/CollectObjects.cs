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
		if(col.gameObject.tag == "Interactable"){
			if(col.gameObject.GetComponent<ShowDialogue>())
				StartCoroutine(col.gameObject.GetComponent<ShowDialogue>().showText());
		}
		else if(col.gameObject.tag == "Collectible"){
			Destroy(col.gameObject);
			scoreText.text = "Score: "+ (++localScore);
		}
	}
}
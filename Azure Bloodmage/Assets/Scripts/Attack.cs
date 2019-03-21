using System;
using UnityEngine;

public class Attack : MonoBehaviour {
	//public GameObject sword;
	public GameObject fireball;
	private GameObject clone;
	
	public void Update(){
		if(Input.GetButtonDown("Fire1")){ //sword
			
		}
		if(Input.GetButtonDown("Fire2")){ //fireball
			Instantiate(fireball, gameObject.transform.position + new Vector3(0,.5f,0) + gameObject.transform.forward*2, Quaternion.identity);
		}
	}
}
using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthPickup : MonoBehaviour{
	public GameObject player;
	private int playerHealth;
	private int playerMaxHealth;
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject == player){
			playerHealth = player.GetComponent<PlayerHealth>().GetCurHealth();
			playerMaxHealth = player.GetComponent<PlayerHealth>().GetMaxHealth();
			//if player's health isn't full
			if(playerHealth < playerMaxHealth){ 
				player.GetComponent<PlayerHealth>().ChangeHealth(30);
				Destroy(this.gameObject);
			}
			else{}
		}
	}
}
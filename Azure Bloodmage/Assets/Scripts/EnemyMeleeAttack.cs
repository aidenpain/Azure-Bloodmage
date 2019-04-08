using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMeleeAttack : MonoBehaviour {
	private GameObject player;
	private int attack;
	
	void Awake(){
		player = GameObject.Find("Player");
		attack = gameObject.GetComponent<EnemyStats>().attack;
	}
	
	void OnCollisionStay(Collision col){
		if(col.gameObject == player){
			col.gameObject.GetComponent<PlayerHealth>().TakeDamage(attack);
		}
	}
}
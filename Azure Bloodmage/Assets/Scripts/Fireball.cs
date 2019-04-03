using System;
using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
	private Transform player;
	public int thrust;
	
	public void Awake(){
		player = GameObject.Find("Player").transform;
		GetComponent<Rigidbody>().AddForce(player.transform.forward*thrust);
		StartCoroutine(TimedDestroy());
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Enemy"){
			col.gameObject.GetComponent<EnemyHealth>().TakeDamage(10);
			Destroy(gameObject);
		}
		else{
			Destroy(gameObject);
		}
	}
	
	public void Update(){

	}
	
	private IEnumerator TimedDestroy(){
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
	}
}
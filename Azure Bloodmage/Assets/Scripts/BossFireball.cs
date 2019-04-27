using System;
using UnityEngine;
using System.Collections;

public class BossFireball : MonoBehaviour {
	public int thrust;

	public void Awake(){
		StartCoroutine(TimedDestroy());
	}

	public void FireFireball(Transform caster){
		GetComponent<Rigidbody>().AddForce(caster.forward*thrust);
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.GetComponent<PlayerHealth>().TakeDamage(15);
			Destroy(gameObject);
		}
		else{
			Destroy(gameObject);
		}
	}
	
	public void Update(){

	}
	
	private IEnumerator TimedDestroy(){
		yield return new WaitForSeconds(10f);
		Destroy(gameObject);
	}
}
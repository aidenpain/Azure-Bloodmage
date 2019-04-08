using System;
using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
	public int thrust;
	private bool isEnemyFireball;
	
	public void Awake(){
		StartCoroutine(TimedDestroy());
	}

	public void FireFireball(Transform caster, bool isEnemyFireball){
		GetComponent<Rigidbody>().AddForce(caster.forward*thrust);
		this.isEnemyFireball = isEnemyFireball;
	}

	void OnCollisionEnter(Collision col){
		if(!(isEnemyFireball) && col.gameObject.tag == "Enemy"){
			col.gameObject.GetComponent<EnemyHealth>().TakeDamage(10);
			Destroy(gameObject);
		}
		else if(isEnemyFireball && col.gameObject.tag == "Player"){
			col.gameObject.GetComponent<PlayerHealth>().TakeDamage(20);
			Destroy(gameObject);
		}
		else{
			Destroy(gameObject);
		}
	}
	
	public void Update(){

	}
	
	private IEnumerator TimedDestroy(){
		yield return new WaitForSeconds(3f);
		Destroy(gameObject);
	}
}
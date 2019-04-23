using System;
using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
	public int thrust;
	private bool isEnemyFireball;
	
	private static int ATTACK_STANCE = 2;	//stances defined as ints for quick and easy comparison
	private static int MAGIC_STANCE = 1;
	private int curStance;
	
	public void Awake(){
		StartCoroutine(TimedDestroy());
	}

	public void FireFireball(Transform caster, bool isEnemyFireball, int stance){
		GetComponent<Rigidbody>().AddForce(caster.forward*thrust);
		this.isEnemyFireball = isEnemyFireball;
		if(!(isEnemyFireball)){
			curStance = stance;
			Debug.Log("Player fireball stance: " + curStance);
		}
	}

	void OnCollisionEnter(Collision col){
		if(!(isEnemyFireball) && col.gameObject.tag == "Enemy"){
			col.gameObject.GetComponent<EnemyHealth>().TakeDamage(10*(2/curStance));	//magic is more powerful in the magic stance
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
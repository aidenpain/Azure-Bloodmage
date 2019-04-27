using System;
using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
	public int thrust;
	private bool isEnemyFireball;
	
    private int curStance;
    private static int ATTACK_STANCE = 2;   //stances defined as ints for quick and easy comparison
    private static int MAGIC_STANCE = 1;
	
	public void Awake(){
		StartCoroutine(TimedDestroy());
	}

	//handles both player and enemy fireballs and changes attack power based on stance
	public void FireFireball(Transform caster, bool isEnemyFireball, int stance){
		if(!(isEnemyFireball)){
			curStance = stance;
			GetComponent<Rigidbody>().AddForce(caster.forward*thrust*(2/curStance));
		}
		else{
			GetComponent<Rigidbody>().AddForce(caster.forward*thrust);
		}
		this.isEnemyFireball = isEnemyFireball;
	}

	void OnCollisionEnter(Collision col){
		if(!(isEnemyFireball) && col.gameObject.tag == "Enemy"){
			col.gameObject.GetComponent<EnemyHealth>().TakeDamage(10*(2/curStance));	//magic is more powerful in the magic stance
			Destroy(gameObject);
		}
		else if(isEnemyFireball && col.gameObject.tag == "Player"){
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
		yield return new WaitForSeconds(3f);
		Destroy(gameObject);
	}
}
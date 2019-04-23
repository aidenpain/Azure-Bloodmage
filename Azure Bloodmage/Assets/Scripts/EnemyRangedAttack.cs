using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRangedAttack : MonoBehaviour {
	public GameObject fireball;
	public float fireRate;
	private int attack;
	private bool follow, prev_follow;
	
	void Awake(){
		prev_follow = gameObject.GetComponent<NPCSimplePatrol>().GetFollow();
	}
	void Update(){
		follow = gameObject.GetComponent<NPCSimplePatrol>().GetFollow();
		//if the enemy just noticed the player, start firing
		if(follow == true && prev_follow == false)
			InvokeRepeating("Fire", 1f, fireRate);
		//if the enemy has lost sight of the player, stop firing
		else if(follow == false && prev_follow == true)
			CancelInvoke();
		prev_follow = follow;
	}
	void Fire(){
		GameObject newFireball = Instantiate(fireball, gameObject.transform.position + new Vector3(0,.5f,0) + gameObject.transform.forward*2, Quaternion.identity);
		newFireball.GetComponent<Fireball>().FireFireball(gameObject.transform, true);
        FindObjectOfType<AudioManager>().Play("EnemyRange");

    }
}
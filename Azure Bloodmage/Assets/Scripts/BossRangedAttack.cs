using System;
using UnityEngine;
using UnityEngine.UI;

public class BossRangedAttack : MonoBehaviour {
	public GameObject fireball;
	public GameObject firePoint;
	public float fireRate;
	
	void Awake(){
		InvokeRepeating("Fire", 1f, fireRate);
	}
	void Update(){
	}
	void Fire(){
		int offset = 1;
		for(int i = 0; i < 10; i++){
			GameObject newFireball = Instantiate(fireball, firePoint.transform.position+new Vector3(0,0,offset), Quaternion.identity);
			newFireball.GetComponent<BossFireball>().FireFireball(firePoint.transform, true, 0);
		offset += 2;
		}
		FindObjectOfType<AudioManager>().Play("EnemyRange");
    }
	
}
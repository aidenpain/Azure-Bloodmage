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
		Vector3 direction;
		Quaternion fireDirection;
		for(int i = 0; i < 15; i++){
			direction = new Vector3(UnityEngine.Random.Range(-1f,1f),UnityEngine.Random.Range(-120f,120f),0);
			fireDirection = Quaternion.Euler(direction);
			GameObject newFireball = Instantiate(fireball, firePoint.transform.position+new Vector3(0,0,offset), fireDirection);
			newFireball.GetComponent<BossFireball>().FireFireball(firePoint.transform);
		//offset += 2;
		}
		FindObjectOfType<AudioManager>().Play("EnemyRange");
    }
	
}
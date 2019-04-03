using System;
using UnityEngine;
//using UnityEngine.UI;

public class Attack : MonoBehaviour {
	public Camera cam;
	public GameObject Hand;
	public Weapon myWeapon;
	Animator handAnim;
	private float attackTimer;
	public float fireballCoolDown;
	
	public GameObject fireball;
	public GameObject reticule;
	
	void Start () {
		handAnim = Hand.GetComponent<Animator>();
		myWeapon = Hand.GetComponentInChildren<Weapon>();
	}
	
	public void Update(){
		RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5f))
			reticule.transform.position = hit.point;
		else
			reticule.transform.localPosition = new Vector3(0,0,5f);

        attackTimer += Time.deltaTime;
		if(Input.GetButtonDown("Fire1") && attackTimer >= myWeapon.attackCoolDown){ //sword
			attackTimer = 0f;
			MeleeAttack();
		}
		else if(Input.GetButtonDown("Fire2") && attackTimer >= fireballCoolDown){ //fireball
			if(GetComponent<PlayerHealth>().DepleteMana(5))
				Instantiate(fireball, gameObject.transform.position + new Vector3(0,.5f,0) + gameObject.transform.forward*2, Quaternion.identity);
		}
	}
	
	private void MeleeAttack()
    {
        RaycastHit hit;

        //if(Physics.Raycast(ray, out hit, myWeapon.attackRange))
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, myWeapon.attackRange))
        {
            if(hit.collider.tag == "Enemy")
            {
                EnemyHealth eHealth = hit.collider.GetComponent<EnemyHealth>();
                eHealth.TakeDamage(myWeapon.attackDamage);
            }
        }

    }
}
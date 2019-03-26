using System;
using UnityEngine;

public class Attack : MonoBehaviour {
	public Camera cam;
	public GameObject Hand;
	public Weapon myWeapon;
	Animator handAnim;
	private float attackTimer;
	public float fireballCoolDown;
	
	public GameObject fireball;
	
	void Start () {
		handAnim = Hand.GetComponent<Animator>();
		myWeapon = Hand.GetComponentInChildren<Weapon>();
	}
	
	public void Update(){
        attackTimer += Time.deltaTime;
		if(Input.GetButtonDown("Fire1") && attackTimer >= myWeapon.attackCoolDown){ //sword
			attackTimer = 0f;
			DoAttack();
		}
		else if(Input.GetButtonDown("Fire2") && attackTimer >= fireballCoolDown){ //fireball
			Instantiate(fireball, gameObject.transform.position + new Vector3(0,.5f,0) + gameObject.transform.forward*2, Quaternion.identity);
		}
	}
	
	private void DoAttack()
    {
        RaycastHit hit;

        //if(Physics.Raycast(ray , out hit, myWeapon.attackRange))
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, myWeapon.attackRange))        
        {
            if(hit.collider.tag == "Enemy")
            {
                EnemyHealth1 eHealth = hit.collider.GetComponent<EnemyHealth1>();
                eHealth.TakeDamage(myWeapon.attackDamage);
            }
        }

    }
}
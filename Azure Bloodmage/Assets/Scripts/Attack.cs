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
	private int thrust;
	private int curStance;
	private static int ATTACK_STANCE = 1;	//stances defined as ints for quick and easy comparison
	private static int DEFENSE_STANCE = 0;
	
	public GameObject fireball;
	public GameObject reticule;
	
	void Start () {
		handAnim = Hand.GetComponent<Animator>();
		myWeapon = Hand.GetComponentInChildren<Weapon>();
		curStance = ATTACK_STANCE;
	}
	
	public void Update(){
		RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f))
			reticule.transform.position = hit.point;
		else
			reticule.transform.localPosition = new Vector3(0,0,10f);

        attackTimer += Time.deltaTime;
		if(Input.GetButtonDown("Fire1") && attackTimer >= myWeapon.attackCoolDown){ //sword
			attackTimer = 0f;
			MeleeAttack();
		}
		else if(Input.GetButtonDown("Fire2") && attackTimer >= fireballCoolDown){ //fireball
			if(curStance == ATTACK_STANCE){
				if(GetComponent<PlayerHealth>().DepleteMana(5)){
					GameObject newFireball = Instantiate(fireball, gameObject.transform.position + new Vector3(0,.5f,0) + 
															gameObject.transform.forward*2, Quaternion.identity);
					newFireball.GetComponent<Fireball>().FireFireball(gameObject.transform, false);
				}
			}		
			else if(curStance == DEFENSE_STANCE){
				if(GetComponent<PlayerHealth>().DepleteMana(5)){
					GameObject newFireball = Instantiate(fireball, gameObject.transform.position + new Vector3(0,.5f,0) + 
															gameObject.transform.forward*2, Quaternion.identity);
					newFireball.GetComponent<Fireball>().FireFireball(gameObject.transform, false);
				}
			}
		}
		else if(Input.GetButtonDown("Switch")){ //switch stance
			if(curStance == ATTACK_STANCE){
				curStance = DEFENSE_STANCE;
			}
			else if(curStance == DEFENSE_STANCE){
				curStance = ATTACK_STANCE;
			}
			Debug.Log(curStance);
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
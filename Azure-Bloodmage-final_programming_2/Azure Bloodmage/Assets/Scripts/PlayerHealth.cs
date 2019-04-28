using System;
using UnityEngine;
using UnityEngine.UI;

//controls both health and mana
public class PlayerHealth : MonoBehaviour {
	private int maxHealth;
	private int curHealth;
	private int maxMana;
	private int curMana;
	
	private GameObject HealthBarInstance;	//specific instance of prefab
	public RectTransform healthBar;			//red bar resizes to show how health is left
	public RectTransform manaBar;			//blue bar resizes to show how mana is left
	public GameObject bgBar;				//background bar
	
	private float healthWidth;	//shows how much health is left
	private float manaWidth;	//shows how much mana is left
	private float barWidth;		//width of original bar
		
	private int iframes;
	private int refresh_frames;
	private int itimer;
	private int refresh_timer;
	
	public void Awake(){
		maxHealth = GetComponent<CharacterStats>().health;
		curHealth = maxHealth;
		maxMana = GetComponent<CharacterStats>().mana;
		curMana = maxMana;
		barWidth = healthBar.rect.width;
		iframes = 30;		//brief invincibility after getting hit
		refresh_frames = 30; //mana refresh rate
		itimer = 0;
		refresh_timer = 0;
	}
	
	
	public void Update(){
		if(itimer < iframes)itimer++;	
		//wait to refill mana
		if(refresh_timer < refresh_frames)refresh_timer++;	
		else{
			if(curMana < maxMana){
				curMana++;
				UpdateMana();
			}
			refresh_timer = 0;
		}
	}

	//take damage from enemies
	public void TakeDamage(int damage){
		//handles mercy invincibility
		if(itimer >= iframes){		
			ChangeHealth(-(damage));
			itimer = 0;
		}
		
		//game over if health drops to 0
		if (curHealth <= 0){
			GetComponent<GameOver>().gameOver();
		}
	}
	
	//increases health when parameter is positive, decreases health when parameter is negative
	public void ChangeHealth(int health){
		//health shouldn't exceed max health
		if(health > (maxHealth - curHealth)){curHealth = maxHealth;}
		else{curHealth += health;}
		
		UpdateHealth();
	}
	
	//the player cannot cast spells without enough mana; otherwise decrease available mana
	//called from Attack script
	public bool DepleteMana(int cost){
		if (curMana < cost){
			return false;
		}
		else{
			curMana -= cost;
			UpdateMana();
			return true;
		}
	}
	
	//health bar resizes when health decreases or increases
	public void UpdateHealth(){
		healthWidth = (float)curHealth/maxHealth*barWidth;
		healthBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, healthWidth);
	}
		
	//mana bar resizes when mana is used or recharged
	public void UpdateMana(){
		manaWidth = (float)curMana/maxMana*barWidth;
		manaBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, manaWidth);
	}
	
	//get methods
	public int GetCurHealth(){
		return curHealth;
	}
	public int GetMaxHealth(){
		return maxHealth;
	}
}
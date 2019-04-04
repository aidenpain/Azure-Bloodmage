using System;
using UnityEngine;
using UnityEngine.UI;

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
	private int timer;
	
	public void Awake(){
		maxHealth = GetComponent<CharacterStats>().health;
		curHealth = maxHealth;
		maxMana = GetComponent<CharacterStats>().mana;
		curMana = maxMana;
		barWidth = healthBar.rect.width;
		iframes = 30;
		refresh_frames = 30;
		itimer = 0;
		timer = 0;
	}
	
	public void Update(){
		if(itimer < iframes)itimer++;
		if(timer < refresh_frames)timer++;
		else{
			if(curMana < maxMana){
				curMana++;
				UpdateMana();
			}
			timer = 0;
		}
	}
	
	void OnCollisionStay(Collision col){
		if(itimer >= iframes){
			if(col.gameObject.tag == "Enemy"){
				TakeDamage(10);
				itimer = 0;
			}
		}
	}
	
	public void TakeDamage(int damage){
		curHealth -= damage;	
		healthWidth = (float)curHealth/maxHealth*barWidth;
		healthBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, healthWidth);
		
		if (curHealth <= 0){
			GetComponent<GameOver>().gameOver();
		}
	}
	
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
	
	public void UpdateMana(){
		manaWidth = (float)curMana/maxMana*barWidth;
		manaBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, manaWidth);
	}
}
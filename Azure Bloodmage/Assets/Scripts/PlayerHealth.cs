using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public Camera cam;
	public int maxHealth;
	private int curHealth;
	
	private GameObject HealthBarInstance;	//specific instance of prefab
	public RectTransform healthBar;	//red bar resizes to show how health is left
	public GameObject bgBar;	//background bar
	
	private float healthWidth;	//shows how much is left
	private float barWidth;		//width of original bar
	
	Color healthColor;
	Color bgBarColor;
	
	private int iframes;
	private int itimer;
	
	public void Awake(){
		curHealth = maxHealth;
		barWidth = healthBar.rect.width;
		healthColor = healthBar.GetComponent<Image>().color;
		bgBarColor = bgBar.GetComponent<Image>().color;
		iframes = 60;
		itimer = 0;
	}
	
	public void Update(){
		if(itimer < iframes)itimer++;
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
}
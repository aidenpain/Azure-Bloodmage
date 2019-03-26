using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth1 : MonoBehaviour {
	private Camera cam;
	public int maxHealth;
	private int curHealth;
	
	public GameObject healthBarPrefab;	//prefab from assets folder
	private GameObject HealthBarInstance;	//specific instance of prefab
	private RectTransform healthBar;	//red bar resizes to show how much health the enemy has left
	private GameObject bgBar;	//background bar
	
	private float healthWidth;	//shows how much is left
	private float barWidth;		//width of original bar
	
	Color healthColor;
	Color bgBarColor;
	
	public void Awake(){
		cam = GameObject.Find("MainCamera").GetComponent<Camera>();
		HealthBarInstance = Instantiate(healthBarPrefab, GameObject.Find("EnemyUIPanel").transform);
		curHealth = maxHealth;
		bgBar = HealthBarInstance.transform.GetChild(0).gameObject;
		healthBar = HealthBarInstance.transform.GetChild(1).GetComponent<RectTransform>();
		barWidth = healthBar.rect.width;
		healthColor = healthBar.GetComponent<Image>().color;
		bgBarColor = bgBar.GetComponent<Image>().color;
	}
	
	public void Update(){
		Vector3 screenPos = cam.WorldToScreenPoint(gameObject.transform.position);	//where the enemy is on screen
		float distance = Vector3.Distance(cam.gameObject.transform.position, gameObject.transform.position);
		//Debug.Log(distance);
		if(screenPos.x <= cam.pixelWidth && screenPos.y <= cam.pixelHeight && distance < 20f){	//show the bar if the enemy is on screen
			if(!(HealthBarInstance.activeSelf))
				HealthBarInstance.SetActive(true);
			if(distance > 10f){ //makes the bar slightly transparent if far away
				healthBar.GetComponent<Image>().color = new Color(healthColor.r, healthColor.g, healthColor.b, 0.5f);
				bgBar.GetComponent<Image>().color = new Color(bgBarColor.r, bgBarColor.g, bgBarColor.b, 0.5f);
			}
			else{
				healthBar.GetComponent<Image>().color = new Color(healthColor.r, healthColor.g, healthColor.b, 1f);
				bgBar.GetComponent<Image>().color = new Color(bgBarColor.r, bgBarColor.g, bgBarColor.b, 1f);
			}
			HealthBarInstance.transform.position = new Vector2(screenPos.x, screenPos.y);
		}
		else	//disable the bar if it's not on screen
			HealthBarInstance.SetActive(false);
	}
	
	public void TakeDamage(int damage){
		curHealth -= damage;
		healthWidth = (float)curHealth/maxHealth*barWidth;
		healthBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, healthWidth);
		
		if (curHealth <= 0){
			
			Destroy(HealthBarInstance.gameObject);
			Destroy(this.gameObject);
		}
	}
}
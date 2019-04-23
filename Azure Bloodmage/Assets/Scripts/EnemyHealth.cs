using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour {
	private Camera cam;
	private int maxHealth;
	private int curHealth;
	
	public GameObject healthBarPrefab;	//prefab from assets folder
	private GameObject HealthBarInstance;	//specific instance of prefab
	private RectTransform healthBar;	//red bar resizes to show how much health the enemy has left
	private GameObject bgBar;	//background bar
	
	private float healthWidth;	//shows how much is left
	private float barWidth;		//width of original bar
	
	Color healthColor;
	Color bgBarColor;
	
	private GameObject player;
	private GameObject scoreTracker;
	
	public void Awake(){
		maxHealth = gameObject.GetComponent<EnemyStats>().health;
		curHealth = maxHealth;
		
		HealthBarInstance = Instantiate(healthBarPrefab, GameObject.Find("EnemyUIPanel").transform);
		bgBar = HealthBarInstance.transform.GetChild(0).gameObject;
		healthBar = HealthBarInstance.transform.GetChild(1).GetComponent<RectTransform>();
		barWidth = healthBar.rect.width;
		healthColor = healthBar.GetComponent<Image>().color;
		bgBarColor = bgBar.GetComponent<Image>().color;

		cam = GameObject.Find("MainCamera").GetComponent<Camera>();
	}
	
	void OnEnable(){
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}
	
	void OnDisable(){
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}
	
	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode){
		scoreTracker = GameObject.Find("ScoreTracker");
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
		
		//if enemy is killed, increase score and destroy enemy game object
		if (curHealth <= 0){
			scoreTracker.GetComponent<ScoreTracker>().IncreaseLocalScore(gameObject.GetComponent<EnemyStats>().score);
			Destroy(HealthBarInstance.gameObject);
			Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().Play("MonsterDeath");
        }
	}
}
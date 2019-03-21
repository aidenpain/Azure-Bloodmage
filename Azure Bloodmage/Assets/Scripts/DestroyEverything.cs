using System;
using UnityEngine;

public class DestroyEverything : MonoBehaviour{
	
	public GameObject player;
	public GameObject ui;
	public GameObject eventsys;

	public void DestroyThings(){
		Destroy(player);
		Destroy(ui);
		Destroy(eventsys);
	}
}
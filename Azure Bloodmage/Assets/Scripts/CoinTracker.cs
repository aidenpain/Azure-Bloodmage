using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinTracker : MonoBehaviour{
	private int numCoins;
	private Text coinsText;
	
	void Start(){
		numCoins = 0;
		coinsText = GameObject.Find("CoinText").GetComponent<Text>();
	}
	
	public void IncreaseNumCoins(int i){
		numCoins += i;
		coinsText.text = "Coins: "+ numCoins;
	}
	
	public int GetNumCoins(){
		return numCoins;
	}
}
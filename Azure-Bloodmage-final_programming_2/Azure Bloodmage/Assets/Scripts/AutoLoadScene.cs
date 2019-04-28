using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AutoLoadScene : MonoBehaviour {
	public int sceneIndex;

    public void Start()
    {
		StartCoroutine(WaitForLoad());
    }
	
	IEnumerator WaitForLoad(){
		yield return new WaitForSeconds(0.1f);
		SceneManager.LoadScene(sceneIndex);
	}
}
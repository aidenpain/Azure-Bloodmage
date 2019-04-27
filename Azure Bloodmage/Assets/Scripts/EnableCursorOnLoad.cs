using UnityEngine;

public class EnableCursorOnLoad : MonoBehaviour {
	void Start(){
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
}
using UnityEngine;
using System.Collections;

public class PauseRes : MonoBehaviour {
	public static bool paused = false;
	public static Canvas can;

	void Start(){
		can = GetComponent<Canvas>();
		can.enabled = false;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			paused = true;
		}
		if (paused) {
			Time.timeScale = 0;
			can.enabled=true;
		}
		else if (!paused)
			Time.timeScale = 1;
	}

	void OnApplicationFocus(bool pauseStatus) {
		if(pauseStatus){
			paused = true;
		}
	}
}

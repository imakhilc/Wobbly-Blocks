using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mute2 : MonoBehaviour {
	public Text img;
	
	public void Start(){
		img=GetComponent<Text>();
	}

	void Update () {
		if (!Mute.mute)
			img.enabled = false;
		else
			img.enabled = true;
	}
}

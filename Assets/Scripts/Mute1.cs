using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mute1 : MonoBehaviour {
	public Text img;

	public void Start(){
		img=GetComponent<Text>();
	}

	public void Update () {
		if (Mute.mute) {
			img.enabled = false;
		}
		else
			img.enabled = true;
	}
}

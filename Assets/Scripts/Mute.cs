using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mute : MonoBehaviour {
	public static bool mute = false;
	public Image img;

	public void MuteButton(){
		mute = !mute;
		img = GetComponentInChildren<Image>();
	}

	public void Update(){
		if (mute) {
			AudioListener.volume = 0;
		}

		if (!mute) {
			AudioListener.volume = 1;
		}
	}
}

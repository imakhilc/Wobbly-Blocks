using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
	
	void Start () {
		Text txt = GetComponent<Text>();	
		txt.text=(""+PlayerPrefs.GetInt("brickScore"));
	}
}

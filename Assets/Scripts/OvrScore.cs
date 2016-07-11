using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OvrScore : MonoBehaviour {

	void Start () {
		Text txt = GetComponent<Text>();	
		txt.text=(""+Score.score);
		print ("");
	}
}

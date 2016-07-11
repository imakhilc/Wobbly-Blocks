using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public Text txt;
	public static int score=0;

	void Start () {
		txt = GetComponent<Text>();	
		transform.Translate (new Vector3(0,0,0));
	}

	void Update () {
		score = CreateBlock.i - 1;
		txt.text=(""+score);
	}
}

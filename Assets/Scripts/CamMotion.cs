using UnityEngine;
using System.Collections;

public class CamMotion : MonoBehaviour {
	public static float camerapos;
	public static bool proceed=true;
	public static bool move=false;
	public static AudioSource audio;
	public float x;

	void Start () {
		x = transform.position.y;
		audio = GetComponent<AudioSource>();
	}

	void Update () {

		camerapos = transform.position.y;
		if ((camerapos-x) >= 0.45f) {
			proceed = false;
			x=camerapos;
		}

		if (move && proceed) {
			transform.Translate (Vector3.up * 10f * Time.deltaTime * .1f);
		}
	}
}

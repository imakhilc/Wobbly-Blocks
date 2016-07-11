using UnityEngine;
using System.Collections;

public class RotateCam : MonoBehaviour {

	void Start () {
		Screen.orientation = ScreenOrientation.Portrait;
		ScreenOrientation.AutoRotation.Equals (false);	
	}
}

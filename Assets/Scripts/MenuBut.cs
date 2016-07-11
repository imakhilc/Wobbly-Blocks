using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class MenuBut : MonoBehaviour {
	public static bool st = true;
	public static bool gconnection = false;

	void Start(){
		//PlayGamesPlatform.Activate();
		//connectGPlay ();
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape) && st) {
			Application.Quit ();
		}
	}

	public void PauseButton(){
		PauseRes.paused = true;
	}

	public void StartButton(){
		st = false;
		Application.LoadLevel ("BlockBalance");
	}
	public void RetryButton(){
		CreateBlock.i = 0;
		CreateBlock.spawn = true;
		CamMotion.move=false;
		PauseRes.paused = false;
		Application.LoadLevel ("BlockBalance");
	}
	public void QuitButton(){
		//Application.Quit ();
		if (Social.localUser.authenticated) {
			Social.ShowLeaderboardUI();
		}
	}
	
	public void RateButton(){
		Application.OpenURL("https://goo.gl/uKWv3u");
	}

	public void HomeButton(){
		PauseRes.paused = false;
		CreateBlock.i = 0;
		CreateBlock.spawn = true;
		CamMotion.move=false;
		Application.LoadLevel ("StartMenu");
	}

	public void ResumeButton(){
		PauseRes.paused = false;
		PauseRes.can.enabled=false;
	}

	public void connectGPlay(){
		if (!gconnection) {
			Social.localUser.Authenticate ((bool success) => {
				gconnection = success;
			});
		}
	}
}

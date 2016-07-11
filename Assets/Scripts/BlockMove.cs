using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlockMove : MonoBehaviour {
	public Rigidbody block;
	public BoxCollider box;
	public Renderer mat;
	public float moveSpeed = 10f;
	public float speed;
	public float speed1=.4f;
	public float speed2=.5f;
	public float speed3=.6f;
	public bool touch = false;
	public static bool right;
	public static float posX=2;
	public int no = Random.Range(1,4);
	public int Ad = Random.Range(1,1);
	public bool once = true;
	public bool tick = true;
	
	void Start () {		
		GoogleMobileAdsDemoScript.showad=false;
		block = GetComponent<Rigidbody>();
		block.mass = 0;
		block.constraints = RigidbodyConstraints.FreezePositionY;

		Material newMat = Resources.Load("Block"+no.ToString(), typeof(Material)) as Material;
		PhysicMaterial newFric = Resources.Load("fricN", typeof(PhysicMaterial)) as PhysicMaterial;
		mat = GetComponent<Renderer>();
		mat.material = newMat;
		box = GetComponent<BoxCollider>();
		box.material = newFric;
		if (no == 1)
			speed = speed1;
		if (no == 2)
			speed = speed2;
		if (no == 3)
			speed = speed3;
	}

	void Update () {

		if (!touch) {
			block.constraints = RigidbodyConstraints.FreezeAll;
			if (block.position.x < 2 && !touch && right)
				transform.Translate (Vector3.right * moveSpeed * Time.deltaTime * speed);
			if (block.position.x > -2 && !touch && !right)
				transform.Translate (Vector3.left * moveSpeed * Time.deltaTime * speed);
			if (block.position.x >= 2)
				right = false;
			if (block.position.x <=-2)
				right = true;
		}

		if (!PauseRes.paused) {
			if (Input.GetKeyDown (KeyCode.Mouse0) || Input.touches.Equals (true)) {
				//print(Input.mousePosition.x+ ","+ Input.mousePosition.y);
				if(false){
					PauseRes.paused = true;
				} else {
					touch = true;			
					posX = block.position.x;
					//block.constraints = RigidbodyConstraints.None;
					block.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
					if (once)
						StartCoroutine (WaitForIt ());
					once = false;
				}
			}
		}

	}

	void OnCollisionEnter(Collision other){
		if(tick)
			StartCoroutine (SoundWait ());
		if (other.gameObject.tag == "fall") {
			if(Ad==1)
				GoogleMobileAdsDemoScript.showad=true;
			if(Score.score > PlayerPrefs.GetInt("brickScore")){
				PlayerPrefs.SetInt("brickScore",Score.score);
			}
			Application.LoadLevel ("GameOver");
		}
	}

	IEnumerator SoundWait() {
			CamMotion.audio.Play ();
			yield return new WaitForSeconds(.001f);
			tick = false;
	}

	IEnumerator WaitForIt() {
		yield return new WaitForSeconds(0.8f);
		CreateBlock.spawn = true;
		CamMotion.move=true;
	}
}

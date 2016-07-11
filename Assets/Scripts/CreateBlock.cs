using UnityEngine;
using System.Collections;

public class CreateBlock : MonoBehaviour {
	public Rigidbody block;
	public static bool spawn =true;
	public GameObject cube;
	public static int i=0;
	public float posY=2f;

	void Start () {
		BlockMove.right=true;
	}

	void Update () {
		if (spawn){
			i++;
			CamMotion.proceed=true;
			cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
			cube.transform.position = new Vector3 (BlockMove.posX, posY, 0);
			cube.transform.localScale = new Vector3 (2, 0.45f, 2);
			cube.AddComponent<Rigidbody> ();
			cube.AddComponent<BlockMove> ();
			cube.name = "Block_" + i.ToString ();	
			cube.tag="brick";
			//print(i);
			posY+=.45f;
			cube.transform.parent = this.transform;
			spawn = false;
		}
	}
}

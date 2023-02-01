using UnityEngine;
using System.Collections;

public class OldParallaxMethod : MonoBehaviour {

	private Transform camera;
	public float scale = 1;

	// Use this for initialization
	void Start () {
	}

	void Awake(){
		camera = Camera.main.transform;
	} 

	void Update () {
		transform.position = new Vector3(camera.position.x * scale, transform.position.y, transform.position.z);
	}
}

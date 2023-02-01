using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	public float parallaxFactor;
	//public float smoothing;

	public Transform camera;
	private Vector2 previousCamPos;

	// Use this for initialization
	void Start () {
		previousCamPos = camera.position;
	}

	void Awake(){
		camera = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		float parallax = (previousCamPos.x - camera.position.x) * parallaxFactor;
	
		float newposition = this.transform.position.x + parallax;

		this.transform.position = new Vector3(newposition,this.transform.position.y,this.transform.position.z);
		//this.transform.position = Vector3.Lerp(this.transform.position,
		  //                                 new Vector3(newposition,this.transform.position.y,this.transform.position.z),
			//				               smoothing * Time.deltaTime);

		previousCamPos = camera.position;
	}
}

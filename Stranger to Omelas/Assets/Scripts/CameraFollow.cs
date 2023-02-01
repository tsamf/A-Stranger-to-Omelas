using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Object.DontDestroyOnLoad(this.gameObject);
		Vector3 position = Camera.main.transform.position;
		position.z = -1;
		transform.position = position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = Camera.main.transform.position;
		position.z = -1;
		transform.position = position;
	}
}

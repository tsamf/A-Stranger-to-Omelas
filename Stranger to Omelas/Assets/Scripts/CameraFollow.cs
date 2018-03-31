using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    GameObject stranger;
    public float minimumCameraX = 0.0f;
    public float maximumCameraX = 0.0f;

    void Awake()
    {
        stranger = GameObject.FindGameObjectWithTag("Stranger");
        float newXPostion = Mathf.Clamp(stranger.transform.position.x, minimumCameraX, maximumCameraX);
        transform.position = new Vector3(newXPostion, transform.position.y, transform.position.z);
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float newXPostion = Mathf.Clamp(stranger.transform.position.x, minimumCameraX, maximumCameraX);
        transform.position = new Vector3(newXPostion, transform.position.y, transform.position.z);
    }
}

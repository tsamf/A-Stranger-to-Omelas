using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMeshNavigator : MonoBehaviour {

    GameObject navigator;

	// Use this for initialization
	void Start () {
       navigator = GameObject.FindGameObjectWithTag("Navigator");
	}

    private void LateUpdate()
    {
        this.transform.position = navigator.transform.position;
    }
}

﻿using UnityEngine;
using System.Collections;

public class endingMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (GameObject.Find ("BGM"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

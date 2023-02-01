using UnityEngine;
using System.Collections;

public class SpriteLoad : MonoBehaviour {

	public GameObject sprite;
	public int dialoguerIndex;
	public float x;
	public float y;


	// Use this for initialization
	void Start () {
		if(!Dialoguer.GetGlobalBoolean(dialoguerIndex))
		{
			Instantiate(sprite,new Vector3(x,y,0) , new Quaternion());
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

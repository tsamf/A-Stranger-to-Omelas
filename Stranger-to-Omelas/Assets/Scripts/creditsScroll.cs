using UnityEngine;
using System.Collections;

public class creditsScroll : MonoBehaviour {

	public float scrollRate;
	public float scrollIncrement;
	public float loadScenePosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			scrollRate = scrollRate * 2;
		}

		if(transform.position.y >= loadScenePosition){
			Globals.levelToLoad = 0;
			Globals.inTransition = true;
		}

		float y = transform.position.y + scrollIncrement * scrollRate * Time.deltaTime;
		transform.position = new Vector3(transform.position.x,y,transform.position.z);
	}
}

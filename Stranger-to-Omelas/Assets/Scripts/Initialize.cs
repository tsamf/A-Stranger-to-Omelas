using UnityEngine;
using System.Collections;

public class Initialize : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Globals.position = new Vector3(-850,-80,0);
		Globals.isFacingRight = true;
		Globals.inConversation = false;
		Globals.inTransition = false;
		Globals.levelToLoad = 2;
		Destroy(GameObject.Find("DialoguerInitializer"));
		Destroy(GameObject.Find ("BGM"));
		Destroy(GameObject.Find ("endingMusic"));
	}
	
	// Update is called once per frame
	void Update () {
		Application.LoadLevel(1);
	}
}

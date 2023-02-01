using UnityEngine;
using System.Collections;

public class LoadEnding : MonoBehaviour {

	public int sceneToLoad;
	void Start () {
	}
	
	// Update is called once per frame

	void Update () {
		if(!Globals.inConversation && Dialoguer.GetGlobalBoolean(10))
		{
			Dialoguer.events.ClearAll();
			Dialoguer.SetGlobalBoolean(10,false);
			Globals.levelToLoad = sceneToLoad;
			Globals.inTransition = true;
		}
	}
}

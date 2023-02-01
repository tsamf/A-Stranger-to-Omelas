using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour { 

	public int sceneToLoad;

	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			Globals.levelToLoad = sceneToLoad;
			Globals.inTransition = true;
		}
	}
}

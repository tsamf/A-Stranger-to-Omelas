using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnMouseClick : MonoBehaviour {

    [Tooltip("Specify the name of the scene to load.")]
    public string sceneToLoad = "";

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(sceneToLoad);
        }		
	}
}

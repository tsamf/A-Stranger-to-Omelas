using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour {

    [Tooltip("Tells trigger which scene to load.")]
    public string SceneToLoad = "";

    private LevelManager sceneManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Load scene " + SceneToLoad);
    }
}

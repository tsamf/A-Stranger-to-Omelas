using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour {

    [Tooltip("Tells trigger which scene to load.")]
    public string sceneToLoad = "";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().LoadLevel(sceneToLoad);
    }
}

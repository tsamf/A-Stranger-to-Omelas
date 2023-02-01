using UnityEngine;
using System.Collections;

public class playAudio : MonoBehaviour {

	public AudioClip clip;
	public int dialoguerIndex;
	public float volume = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	if(Dialoguer.GetGlobalBoolean(dialoguerIndex)){

		if (clip != null) {
						AudioSource.PlayClipAtPoint (clip, transform.position, volume);
				}
			Dialoguer.SetGlobalBoolean(dialoguerIndex,false);
	}
}
}

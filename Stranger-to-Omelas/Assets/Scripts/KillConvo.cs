using UnityEngine;
using System.Collections;

public class KillConvo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Globals.inConversation == false){
			Destroy(this.gameObject);
	}
}
}

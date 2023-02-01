using UnityEngine;
using System.Collections;

public class DroozeTrigger : MonoBehaviour {

	public GameObject Drooze;
	public int dialoguerIndex;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Dialoguer.GetGlobalBoolean(dialoguerIndex) && !Globals.inConversation)
		{
			Vector3 backgroundPositon = Camera.main.transform.position;
			backgroundPositon.z = -1;
			Instantiate(Drooze,backgroundPositon, new Quaternion());
			Dialoguer.SetGlobalBoolean(dialoguerIndex,false);
		}
	}
}

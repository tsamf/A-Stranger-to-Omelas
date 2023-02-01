using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeaveEarly : MonoBehaviour {

	private Transform playerCheck;
	private bool colliding = false;
	public DialoguerGui dialoguerGui;
	public int dialogueIndex;
	public playerMovement playermovement;
	public float timepassed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		colliding = Physics2D.Linecast(transform.position, transform.position, 1 << LayerMask.NameToLayer("Player"));

		timepassed += Time.deltaTime;

		if(colliding && !Dialoguer.GetGlobalBoolean(12) && !Dialoguer.GetGlobalBoolean(13) && timepassed > 1){
			Dialoguer.events.ClearAll();
			dialoguerGui.AddDialoguerEvents();
			Dialoguer.StartDialogue(dialogueIndex,DialoguerCallBack);
			this.enabled = false;
			timepassed = 0;
		}
		else if(Dialoguer.GetGlobalBoolean(12)){
			Globals.levelToLoad = 6;
			Dialoguer.SetGlobalBoolean(11,true);
			Globals.inTransition = true;
			timepassed = 0;
		}
		else if(Dialoguer.GetGlobalBoolean(13)){
			Dialoguer.SetGlobalBoolean(13,false);

			//make him walk back
			List<Vector3> node =  new List<Vector3>();
			node.Add(new Vector3(-800,-80,0));
			playermovement.path = node;
			timepassed = 0;
		}
	}

	private void DialoguerCallBack(){
		this.enabled = true;
	}
}

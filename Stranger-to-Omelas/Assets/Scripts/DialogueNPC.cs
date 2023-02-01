using UnityEngine;
using System.Collections;

public class DialogueNPC : MonoBehaviour {

	public int dialogueIndex;
	public AudioClip clip;
	public float volume = 1;

	public playerMovement pmovement;

	public Texture2D cursorOnTexture;
	public Texture2D cursorOffTexture;
	protected CursorMode cursorMode = CursorMode.Auto;
	protected Vector2 hotSpot = Vector2.zero;

	protected float timeIncrement = 1;
	protected float timepassedSinceLast;

	//Conversation Object
	public DialoguerGui dialoguerGui;

	void Start () {
		Dialoguer.events.ClearAll();
	}
	
	// Update is called once per frame
	void Update () {
		if(Globals.inConversation)
		{
			timepassedSinceLast = 0;
		}
		else
		{
			timepassedSinceLast += Time.deltaTime;
		}
	}

	private void OnMouseEnter () {
		if(!Globals.inConversation)
			Cursor.SetCursor(cursorOnTexture, hotSpot, cursorMode);
	}
	private void OnMouseExit () {
		Cursor.SetCursor(cursorOffTexture, Vector2.zero, cursorMode);
	}

	void OnMouseDown(){
		if(!Globals.inConversation && !Globals.inPause && timepassedSinceLast > timeIncrement ){

			if(pmovement.path != null)
			{
				pmovement.path = null;
			}

			if(clip != null)
				AudioSource.PlayClipAtPoint(clip, transform.position, volume);
			
			if(dialogueIndex == -1)
			{}
			//initialize dialogue
			else
			{
				Dialoguer.events.ClearAll();
				dialoguerGui.AddDialoguerEvents();
				Dialoguer.StartDialogue(dialogueIndex,DialoguerCallBack);
				this.enabled = false;
			}
		}
	}
	
	private void DialoguerCallBack(){
		this.enabled = true;
	}
}

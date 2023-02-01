using UnityEngine;
using System.Collections;

public class SceneTransition : MonoBehaviour {

	public int TransitionTo;
	public Vector3 position;
	public bool facingRight;
	public bool leaveCity = false;
	private bool colliding = false;

	// Use this for initialization
	void Awake() {
	}

	void Update () {
		colliding = Physics2D.Linecast(transform.position, transform.position, 1 << LayerMask.NameToLayer("Player"));

		if(colliding)
		{
			Globals.position = position;
			Globals.isFacingRight = facingRight;
			Globals.inTransition = true;
			Globals.levelToLoad = TransitionTo;

			if(leaveCity)
				Dialoguer.SetGlobalBoolean(11,true);
		}	
	}
}

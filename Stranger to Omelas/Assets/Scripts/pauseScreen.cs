using UnityEngine;
using System.Collections;

public class pauseScreen : MonoBehaviour {

	public float pauseAfter;
	public GameObject backGround;
	public Font myfont;

	protected GUIStyle choiceStyle = new GUIStyle();
	protected float timepassed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void OnGUI() {
		timepassed += Time.deltaTime;

		choiceStyle = new GUIStyle(GUI.skin.button);
		choiceStyle.normal.textColor = Color.black;
		choiceStyle.hover.textColor = Color.white;
		choiceStyle.fontSize = 20;
		choiceStyle.font = myfont;
		choiceStyle.wordWrap = true;
		choiceStyle.stretchHeight = true;
		choiceStyle.alignment = TextAnchor.MiddleCenter;
		GUI.backgroundColor = Color.clear;

		if(Input.GetMouseButtonDown(0))
		{
			timepassed = 0;	
		}

		if(timepassed >= pauseAfter && !Globals.inPause)
		{
			Globals.inPause = true;

			Vector3 backgroundPositon = Camera.main.transform.position;
			backgroundPositon.z = 0;
			Instantiate(backGround,backgroundPositon, new Quaternion());
		}

		if(Globals.inPause)
		{
			if(GUI.Button(new Rect(256,325,512,59),"Continue",choiceStyle)){
				Destroy(GameObject.Find(backGround.name + "(Clone)"));
				Globals.inPause = false;
			}
			if(GUI.Button(new Rect(256,384,512,59),"Restart",choiceStyle)){
				Destroy(GameObject.Find(backGround.name + "(Clone)"));
				Globals.inPause = false;
				Globals.levelToLoad = 0;
				Globals.inTransition = true;
			}
		}
	}
}

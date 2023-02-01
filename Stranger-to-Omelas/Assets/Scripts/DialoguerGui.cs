using UnityEngine;
using System.Collections;

public class DialoguerGui : MonoBehaviour {

	private bool showing;
	private string textResponse;
	private string[] choices;
	private GUIStyle textStyle = new GUIStyle();
	private GUIStyle choiceStyle = new GUIStyle();
	public Font myfont;

	//dialogue sprites
	public GameObject backGround;

	public float timepassed = 0;
	public float timeincrement = 1;


	//window calulation variables
	protected float topCorner = 210;
	protected float bottomCorner;
	protected float responseHeight;

	protected float lastwindowbottomcorner;
	protected float rowHeight = 45;
	protected int textRowCount = 0;

	void Start () {
	}

	public void AddDialoguerEvents()
	{
		Dialoguer.events.onStarted += onStarted;
		Dialoguer.events.onEnded += onEnded;
		Dialoguer.events.onTextPhase += onTextPhase;
	}

	void OnGUI(){
		if(!showing)
			return;

		timepassed += Time.deltaTime;

		choiceStyle = new GUIStyle(GUI.skin.button);
		//choiceStyle
		choiceStyle.normal.textColor = new Color (.8f, .7f, .5f, 1);
		choiceStyle.hover.textColor = new Color (.15f, .1f, .05f);
		choiceStyle.fontSize = 20;
		choiceStyle.font = myfont;
		choiceStyle.wordWrap = true;
		choiceStyle.stretchHeight = true;
		choiceStyle.alignment = TextAnchor.MiddleCenter;

		GUI.backgroundColor = Color.clear;

		textStyle = new GUIStyle(GUI.skin.button);
		textStyle.normal.textColor = new Color (.95f, .75f, .65f, 1);
		textStyle.fontSize = 20;
		textStyle.font = myfont;
		textStyle.wordWrap = true;

		CalulateWidnowSize();

		if(textRowCount <= 1)
		{
			textStyle.alignment = TextAnchor.MiddleCenter;
		}
		else if (textRowCount > 1)
		{
			textStyle.alignment = TextAnchor.MiddleLeft;
		}

		GUI.Label(new Rect(256,topCorner,512,responseHeight),textResponse,textStyle);

		if(choices == null ){
			if(Input.GetMouseButtonDown(0) && timepassed >= timeincrement){
				Dialoguer.ContinueDialogue();
				timepassed = 0;
			}
		}else{
			for(int i= 0; i < choices.Length;i ++){
				if(GUI.Button(CalculateChoiceRectangle(256,lastwindowbottomcorner,choices[i]),choices[i],choiceStyle) && timepassed >= timeincrement){
					Dialoguer.ContinueDialogue(i);
					timepassed = 0;
					break;
				}
			}
		}
	}
	

	private void onStarted(){
		showing = true;
		Globals.inConversation = true;
		LoadScene();
	}

	private void onEnded(){
		showing = false;

		if(backGround != null)
			//Destroy(GameObject.Find(backGround.name + "(Clone)"));

		Globals.inConversation = false;
	}

	private void onTextPhase(DialoguerTextData data){
		textResponse = data.text;
		choices = data.choices;
	}

	void LoadScene()
	{
		//background
		if(backGround != null)
		{
			Vector3 backgroundPositon = Camera.main.transform.position;
			backgroundPositon.z = 0;
			Instantiate(backGround,backgroundPositon, new Quaternion());
		}
	}

	void CalulateWidnowSize()
	{
		//int width;
		float height;

		textRowCount = 0;
		int choicesRowCount = 0;


		textRowCount = textResponse.Length/60;
		if(textResponse.Length%60 > 0)
			textRowCount++;

		if(choices != null)
		{
			foreach(string s in choices)
			{
				choicesRowCount += s.Length/60;
				if(s.Length%60 > 0)
					choicesRowCount++;
			}
		}

		height = (textRowCount + choicesRowCount)*rowHeight;

		responseHeight = textRowCount * rowHeight;
		bottomCorner = topCorner + responseHeight;
		lastwindowbottomcorner = bottomCorner;

	}

	Rect CalculateChoiceRectangle(float left, float top, string text)
	{
		int rowCount = text.Length/60;
		if(text.Length%60 > 0)
			rowCount++;

		lastwindowbottomcorner = lastwindowbottomcorner + rowHeight*rowCount;
		return new Rect(left,top,530,rowHeight*rowCount);
	}
}

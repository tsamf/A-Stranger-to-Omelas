using UnityEngine;
using System.Collections;

public class LoadEndingImage : MonoBehaviour {


	public GameObject stay;
	public GameObject leaveResident;
	public GameObject leaveWithChild;
	public GameObject decision;
	public GameObject leaveNonResident;

	public int levelToLoad;
	public bool firstEnding;
	public float timepassed = 0;

	// Use this for initialization
	void Start () {
		float stayf = Dialoguer.GetGlobalFloat(1);
		float leavef = Dialoguer.GetGlobalFloat(2);
		float leaveWithChildf = Dialoguer.GetGlobalFloat(0);

		if(Dialoguer.GetGlobalBoolean(11))
		{
			Instantiate(leaveNonResident,new Vector3(0,0,0), new Quaternion());

		}
		else
		{
			if( stayf  >= 2.0f)
			{
				Instantiate(stay,new Vector3(0,0,0), new Quaternion());
			}
			else if( leavef >= 2.0f)
			{
				Instantiate(leaveResident,new Vector3(0,0,0), new Quaternion());
			}
			else if( leaveWithChildf >= 2.0f)
			{
				Instantiate(leaveWithChild,new Vector3(0,0,0), new Quaternion());
			}
			else
			{
				Instantiate(decision,new Vector3(0,0,0), new Quaternion());
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		timepassed += Time.deltaTime;

		if(Input.GetMouseButtonDown(0) && timepassed > 3)
		{
			if(firstEnding)
			{
				Application.LoadLevel(levelToLoad);
			}
			else
			{
				if(!Globals.inTransition)
				{
					Globals.levelToLoad = levelToLoad;
					Globals.inTransition = true;
				}
			}
		}
		else if(timepassed > 120)
		{
			if(firstEnding)
			{
				Application.LoadLevel(levelToLoad);
			}
			else
			{
				if(!Globals.inTransition)
				{
					Globals.levelToLoad = levelToLoad;
					Globals.inTransition = true;
				}
			}
		}
	}
}

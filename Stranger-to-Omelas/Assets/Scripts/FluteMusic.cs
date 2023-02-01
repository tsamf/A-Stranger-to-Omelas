using UnityEngine;
using System.Collections;

public class FluteMusic : MonoBehaviour {

	GameObject BGMobj;
	GameObject FluteObj;

	float maxBGM = .13f;

	float gameIncrement = .1f;
	float timePassed = 0;


	// Use this for initialization
	void Start () {
		BGMobj = GameObject.Find("BGM");
		FluteObj = GameObject.Find("FluteSound");
	}
	
	// Update is called once per frame
	void Update () {
		timePassed += Time.deltaTime;

		if(timePassed >= gameIncrement)
		{
			timePassed = 0;

			if(!Dialoguer.GetGlobalBoolean(5))
			{
				//lower bg music
				if(BGMobj.GetComponent<AudioSource>().volume > 0)
				{
					BGMobj.GetComponent<AudioSource>().volume = BGMobj.GetComponent<AudioSource>().volume - .01f;
				}

				//raise flute music
				if(FluteObj.GetComponent<AudioSource>().volume < 1)
				{
					FluteObj.GetComponent<AudioSource>().volume = FluteObj.GetComponent<AudioSource>().volume + .1f;
				}
			}
			else if(Dialoguer.GetGlobalBoolean(5))
			{
				//raise bg music
				if(BGMobj.GetComponent<AudioSource>().volume < maxBGM)
				{
					BGMobj.GetComponent<AudioSource>().volume = BGMobj.GetComponent<AudioSource>().volume + .01f;
				}

				//lower flute music
				if(FluteObj.GetComponent<AudioSource>().volume > 0)
				{
					FluteObj.GetComponent<AudioSource>().volume = FluteObj.GetComponent<AudioSource>().volume - .1f;
				}
			}
		}
	}

	void OnDestroy(){
		BGMobj.GetComponent<AudioSource>().volume = maxBGM;
	}
}

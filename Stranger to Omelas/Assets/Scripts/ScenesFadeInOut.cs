using UnityEngine;
using System.Collections;

public class ScenesFadeInOut : MonoBehaviour 
{
	public float fadeSpeed = 1f;
	public bool sceneStarting = true;
	public bool SkipFadeIn = false;
	public bool SkipFadeOut = false;

	void Awake()
	{
		GetComponent<GUITexture>().pixelInset = new Rect(0,0,Screen.width,Screen.height);
	}

	void Update()
	{
		if(sceneStarting)
		{
			if(SkipFadeIn)
			{
				GetComponent<GUITexture>().color = Color.clear;
				GetComponent<GUITexture>().enabled = false;
				sceneStarting = false;
			}
			else{
				StartScene();
			}
		}
		if(Globals.inTransition)
		{
			if(SkipFadeOut)
			{
				Globals.inTransition = false;
				Application.LoadLevel(Globals.levelToLoad);
			}
			else
			{
				EndScene();
			}
		}
	}

	void FadeToClear()
	{

		Color c = GetComponent<GUITexture>().color;
		c.a = GetComponent<GUITexture>().color.a - fadeSpeed * Time.deltaTime; 
		GetComponent<GUITexture>().color = c;
		//guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
	}

	void FadeToBlack()
	{
		Color c = GetComponent<GUITexture>().color;
		c.a = GetComponent<GUITexture>().color.a + fadeSpeed * Time.deltaTime; 
		GetComponent<GUITexture>().color = c;
		//guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
	}

	void StartScene()
	{
		FadeToClear();

		if(GetComponent<GUITexture>().color.a <= 0.05f)
		{
			GetComponent<GUITexture>().color = Color.clear;
			GetComponent<GUITexture>().enabled = false;
			sceneStarting = false;
		}
	}

	public void EndScene()
	{
		sceneStarting = false;
		GetComponent<GUITexture>().enabled = true;
		FadeToBlack();

		if(GetComponent<GUITexture>().color.a >= 0.95f)
		{
			Globals.inTransition = false;
			Application.LoadLevel(Globals.levelToLoad);
		}
	}
}

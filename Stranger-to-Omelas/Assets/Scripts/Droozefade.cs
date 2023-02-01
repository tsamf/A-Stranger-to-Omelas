using UnityEngine;
using System.Collections;

public class Droozefade : MonoBehaviour {


	public SpriteRenderer renderer;
	public float fadeSpeed = .05f;
	public float fadeIncrement = .1f;
	float timesincelastFade = 0f;

	float buzzIncrement = 15f;
	float buzztimepassed = 0f;


	bool FadingIn = true;
	bool FadingOut = false;

	// Use this for initialization
	void Start () {
		Color c = renderer.color;
		c.a = 0;
		renderer.color = c;
	}
	
	// Update is called once per frame
	void Update () {
		timesincelastFade += Time.deltaTime;
		buzztimepassed += Time.deltaTime;

		if(timesincelastFade > fadeIncrement)
		{

			if(FadingIn)
			{
				StartScene();
			}
			else if(FadingOut)
			{
				EndScene();
			}
			timesincelastFade = 0;
		}
		if(buzztimepassed > buzzIncrement)
		{
			FadingOut = true;
		}
	}


	void FadeToClear()
	{
		
		Color c = renderer.color;
		c.a = renderer.color.a - fadeSpeed * Time.deltaTime; 
		renderer.color = c;
		//guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	void FadeToBlack()
	{
		Color c = renderer.color;
		c.a = renderer.color.a + fadeSpeed * Time.deltaTime; 
		renderer.color = c;
		//guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	void StartScene()
	{
		FadeToBlack();
		
		if(renderer.color.a >= 0.5f)
		{
			FadingIn = false;
		}
	}

	public void EndScene()
	{
		FadingOut = false;
		FadeToClear();
		
		if(renderer.color.a <= 0.05f)
		{
			FadingOut = false;
		}
	}
}

using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	private bool fadeIn = true;
	private Color color;
	public float rate = 1;
	// Use this for initialization

	void Start () {
		color = GetComponent<GUIText>().material.color;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(fadeIn == true)
		{
			if(GetComponent<GUIText>().material.color.a < 1)
			{
				color.a += rate * Time.deltaTime;
				GetComponent<GUIText>().material.color = color;
			}
			else
			{
				fadeIn = false;
			}
		}
		else
		{
			if(GetComponent<GUIText>().material.color.a > 0)
			{
				color.a -= rate * Time.deltaTime;
				GetComponent<GUIText>().material.color = color;
			}
			else
			{
				fadeIn = true;
			}
		}
	}
}

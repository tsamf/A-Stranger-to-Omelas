using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInAndOut : MonoBehaviour {

    [Tooltip("How fast the test fades in and out.")]
    public float fadeRate = 1f;

    private Text text;
    private bool isFading = true;

    //Add reference to objets text component
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    void Update ()
    {
	    if(isFading)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime * fadeRate));

            if(text.color.a <= 0.2f)
            {
                isFading = false;
            }
        }
        else
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime * fadeRate));

            if(text.color.a >= 0.9f)
            {
                isFading = true;
            }
        }
	}
}

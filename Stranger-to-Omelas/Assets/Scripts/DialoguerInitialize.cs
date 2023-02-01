using UnityEngine;
using System.Collections;

public class DialoguerInitialize : MonoBehaviour {

	public GameObject obj;

	//public Texture2D cursorOnTexture;
	//protected CursorMode cursorMode = CursorMode.Auto;
	//protected Vector2 hotSpot = Vector2.zero;


	void Awake(){
		Dialoguer.Initialize();
		//Cursor.SetCursor(cursorOnTexture, hotSpot, cursorMode);
	}

	// Use this for initialization
	void Start () {
		Object.DontDestroyOnLoad(obj);

	}
	
	// Update is called once per frame
	void Update () {


	}
}

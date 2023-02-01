using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour {


	private Transform player;

	public float xSmooth = 8f;
	public int frameRate = 60;
	public int deadZoneX = 512;

	private Vector2 minXY;
	private Vector2 maxXY;

	void Start()
	{
		Application.targetFrameRate= frameRate;
		minXY = new Vector2(-deadZoneX,0);
		maxXY = new Vector2(deadZoneX, 0);
	}

	// Use this for initialization
	void Awake() {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

		float targetX = transform.position.x;
		targetX = Mathf.Lerp (transform.position.x,player.position.x,xSmooth *Time.deltaTime);

		this.transform.position =new Vector3(
			Mathf.Clamp(targetX,minXY.x,maxXY.x),
			Mathf.Clamp(player.position.y,minXY.y,maxXY.y),
			-10);
	}
}

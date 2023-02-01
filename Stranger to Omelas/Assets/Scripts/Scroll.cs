using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public float speed;
	public float resetPositionX;
	public float maxPositionX;
	public bool right;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(right)
		{
			transform.position = new Vector3((transform.position.x + speed * Time.deltaTime),transform.position.y,transform.position.z);
		}
		else
		{
			transform.position = new Vector3((transform.position.x - speed * Time.deltaTime),transform.position.y,transform.position.z);
		}

		if (transform.position.x > maxPositionX && right)
		{
			transform.position = new Vector3(resetPositionX,transform.position.y,transform.position.z);
		}
		else if(transform.position.x < maxPositionX && !right)
		{
			transform.position = new Vector3(resetPositionX,transform.position.y,transform.position.z);
		}
	}	
}

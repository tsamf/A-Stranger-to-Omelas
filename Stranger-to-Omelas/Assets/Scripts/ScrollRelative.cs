using UnityEngine;
using System.Collections;

public class ScrollRelative : MonoBehaviour {

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
			transform.localPosition = new Vector3((transform.localPosition.x + speed * Time.deltaTime),transform.localPosition.y,transform.localPosition.z);
		}
		else
		{
			transform.localPosition = new Vector3((transform.localPosition.x - speed * Time.deltaTime),transform.localPosition.y,transform.localPosition.z);
		}
		
		if (transform.localPosition.x > maxPositionX && right)
		{
			transform.localPosition = new Vector3(resetPositionX,transform.localPosition.y,transform.localPosition.z);
		}
		else if(transform.localPosition.x < maxPositionX && !right)
		{
			transform.localPosition = new Vector3(resetPositionX,transform.localPosition.y,transform.localPosition.z);
		}
	}	
}

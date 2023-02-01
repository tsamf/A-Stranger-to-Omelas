using UnityEngine;
using System.Collections;

public class PlayerAnimate : MonoBehaviour {

	protected Animator animator;

	void Start () {
		animator = GetComponent<Animator>();
		animator.SetBool("Walking", false);
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if(Input.GetKey(KeyCode.D))
		{
			animator.SetBool("Walking", true);
		}
		if(Input.GetKey(KeyCode.A))
		{
			animator.SetBool("Walking", true);
		}
		if(Input.GetKey(KeyCode.W))
		{
			animator.SetBool("Walking", true);
		}
		if(Input.GetKey(KeyCode.S))
		{
			animator.SetBool("Walking", true);
		}
		if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
		{
			animator.SetBool("Walking", false);
		}
		*/
	}
}

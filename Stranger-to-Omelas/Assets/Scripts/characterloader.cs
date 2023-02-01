using UnityEngine;
using System.Collections;

public class characterloader : MonoBehaviour {

	public int globalVariableIndex;
	protected Animator animator;


	void Start () {
		animator = GetComponent<Animator>();
		animator.SetBool("sawFlute", Dialoguer.GetGlobalBoolean(globalVariableIndex));
	}

	void Update () {
		animator.SetBool("sawFlute", Dialoguer.GetGlobalBoolean(globalVariableIndex));
	}
}

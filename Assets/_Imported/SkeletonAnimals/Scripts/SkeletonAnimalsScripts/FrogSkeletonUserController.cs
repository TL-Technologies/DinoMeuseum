using UnityEngine;
using System.Collections;

public class FrogSkeletonUserController : MonoBehaviour {
	FrogSkeletonCharacter frogCharacter;

	void Start () {
		frogCharacter = GetComponent < FrogSkeletonCharacter> ();
	}

	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			frogCharacter.Jump();
		}

		if (Input.GetButtonDown ("Fire1")) {
			frogCharacter.Attack();
		}

	}
	
	private void FixedUpdate()
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		frogCharacter.Move (v,h);
	}
}

using UnityEngine;
using System.Collections;

public class LionSkeletonUserController : MonoBehaviour {
	LionSkeletonCharacter lionCharacter;

	void Start () {
		lionCharacter = GetComponent<LionSkeletonCharacter> ();	
	}
	
	void Update(){
		if (Input.GetButtonDown ("Jump")) {
			lionCharacter.Jump();
		}

		if (Input.GetButtonDown ("Fire1")) {
			lionCharacter.Attack();
		}

		if (Input.GetKey (KeyCode.P)) {
			lionCharacter.Punch();
		}

	}

	
	void FixedUpdate(){
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
		lionCharacter.Move (v,h);		
	}
}

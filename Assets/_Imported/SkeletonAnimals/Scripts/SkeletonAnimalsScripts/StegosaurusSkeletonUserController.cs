using UnityEngine;
using System.Collections;

public class StegosaurusSkeletonUserController : MonoBehaviour {

	StegosaurusSkeletonCharacter stegosaurusSkeletonCharacter;

	void Start () {
		stegosaurusSkeletonCharacter = GetComponent<StegosaurusSkeletonCharacter> ();	
	}

	void FixedUpdate(){

		if (Input.GetKey (KeyCode.E)) {
			stegosaurusSkeletonCharacter.Eat();
		}

		if (Input.GetButtonDown ("Fire1")) {
			stegosaurusSkeletonCharacter.Attack();
		}

		if (Input.GetKey (KeyCode.H)) {
			stegosaurusSkeletonCharacter.Hit();
		}

		if (Input.GetKey (KeyCode.N)) {
			stegosaurusSkeletonCharacter.SitDown();
		}

		if (Input.GetKey (KeyCode.U)) {
			stegosaurusSkeletonCharacter.StandUp();
		}


		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
		stegosaurusSkeletonCharacter.Move (v,h);	
	}
}

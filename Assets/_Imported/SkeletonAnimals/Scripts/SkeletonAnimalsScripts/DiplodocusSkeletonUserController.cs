using UnityEngine;
using System.Collections;

public class DiplodocusSkeletonUserController : MonoBehaviour {
	
	DiplodocusSkeletonCharacter diplodocusSkeletonCharacter;
	
	void Start () {
		diplodocusSkeletonCharacter = GetComponent<DiplodocusSkeletonCharacter> ();	
	}
	
	void FixedUpdate(){

		if (Input.GetButtonDown ("Fire1")) {
			diplodocusSkeletonCharacter.Attack();
		}
		
		if (Input.GetKey (KeyCode.H)) {
			diplodocusSkeletonCharacter.Hit();
		}

		if (Input.GetKeyDown(KeyCode.T)) {
			diplodocusSkeletonCharacter.TailAttack();
		}

		
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
		diplodocusSkeletonCharacter.Move (v,h);	
	}
}

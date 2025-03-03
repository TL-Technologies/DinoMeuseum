using UnityEngine;
using System.Collections;

public class ElephantSkeletonUserController : MonoBehaviour {
	
	ElephantSkeletonCharacter elephantSkeletonCharacter;
	
	void Start () {
		elephantSkeletonCharacter = GetComponent<ElephantSkeletonCharacter> ();	
	}
	
	void FixedUpdate(){

		if (Input.GetButtonDown ("Fire1")) {
			elephantSkeletonCharacter.Attack();
		}
		
		if (Input.GetKey (KeyCode.H)) {
			elephantSkeletonCharacter.Hit();
		}
		
		if (Input.GetKey (KeyCode.N)) {
			elephantSkeletonCharacter.SitDown();
		}
		
		if (Input.GetKey (KeyCode.U)) {
			elephantSkeletonCharacter.StandUp();
		}
		
		
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
		elephantSkeletonCharacter.Move (v,h);	
	}
}

using UnityEngine;
using System.Collections;

public class TriceratopsSkeletonUserController : MonoBehaviour {

	
	TriceratopsSkeletonCharacter triceratopsSkeletonCharacter;
	
	void Start () {
		triceratopsSkeletonCharacter = GetComponent<TriceratopsSkeletonCharacter> ();	
	}
	
	void FixedUpdate(){
		
		if (Input.GetKey (KeyCode.E)) {
			triceratopsSkeletonCharacter.Eat();
		}
		
		if (Input.GetButtonDown ("Fire1")) {
			triceratopsSkeletonCharacter.Attack();
		}

		if (Input.GetKey (KeyCode.L)) {
			triceratopsSkeletonCharacter.AttackLeft();
		}

		if (Input.GetKey (KeyCode.R)) {
			triceratopsSkeletonCharacter.AttackRight();
		}

		if (Input.GetKey (KeyCode.H)) {
			triceratopsSkeletonCharacter.Hit();
		}
		
		if (Input.GetKey (KeyCode.N)) {
			triceratopsSkeletonCharacter.SitDown();
		}
		
		if (Input.GetKey (KeyCode.U)) {
			triceratopsSkeletonCharacter.StandUp();
		}
		
		
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
		triceratopsSkeletonCharacter.Move (v,h);	
	}
}

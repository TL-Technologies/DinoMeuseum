using UnityEngine;
using System.Collections;

public class OwlSkeletonUserController : MonoBehaviour {
	public OwlSkeletonCharacter owlCharacter;
	void Start () {
		owlCharacter = GetComponent<OwlSkeletonCharacter> ();	
	}
	
	void Update(){
		if (Input.GetKeyDown(KeyCode.L)) {
			owlCharacter.Landing();
		}
		if (Input.GetKeyDown(KeyCode.H)) {
			owlCharacter.Hit();
		}		
		if (Input.GetButtonDown ("Jump")) {
			owlCharacter.Soar ();
		}		
		if (Input.GetButtonDown ("Fire1")) {
			owlCharacter.Attack ();
		}	
	}
	
	void FixedUpdate(){
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
		owlCharacter.Move (v,h);		
	}
	
}

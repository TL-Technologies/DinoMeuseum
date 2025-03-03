using UnityEngine;
using System.Collections;

public class FrogSkeletonCharacter : MonoBehaviour {
	Animator frogAnimator;
	public float groundCheckDistance=.3f;
	public float groundCheckOffset=1.1f;
	public bool isGrounded=false;

	void Start () {
		frogAnimator = GetComponent<Animator> ();
	}

	void Update () {
		GroundedCheck ();			
	}
	
	public void Jump(){
		if (isGrounded) {
			frogAnimator.SetTrigger ("Jump");
		
		}
	}

	public void Attack(){
		frogAnimator.SetTrigger ("Attack");
	}

	void GroundedCheck(){
		RaycastHit hitInfo;
		if (Physics.Raycast (transform.position+Vector3.up*groundCheckOffset, Vector3.down, out hitInfo, groundCheckDistance)) {
			isGrounded = true;

		}else{
			isGrounded=false;
		}		
		
	}
	
	public void Move(float v,float h){
		frogAnimator.SetFloat ("Forward", v);
		frogAnimator.SetFloat ("Turn", h);
	}

}

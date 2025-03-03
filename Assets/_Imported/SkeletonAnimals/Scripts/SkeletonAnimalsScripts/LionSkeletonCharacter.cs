using UnityEngine;
using System.Collections;

public class LionSkeletonCharacter : MonoBehaviour {
	public Animator lionAnimator;
	public float lionSpeed=2f;
	public bool isGrounded=false;
	public bool jumpUp=false;
	public float jumpSpeed=5f;
	public float groundCheckOffset=0.3f;
	public float groundCheckDistance=.8f;
	
	void Start () {
		lionAnimator = GetComponent<Animator> ();
		lionAnimator.speed = lionSpeed;
	}

	void Update () {
		GroundedCheck ();			
	}

	void GroundedCheck(){
		if (jumpUp) {
			if(lionAnimator.GetCurrentAnimatorClipInfo (0) [0].clip.name == "Fly"){
				jumpUp=false;
			}
		}
		
		if (!jumpUp & Physics.Raycast (transform.position + Vector3.up * groundCheckOffset, Vector3.down, groundCheckDistance)) {
			if (!isGrounded) {
				lionAnimator.SetBool ("Landing", true);
				lionAnimator.applyRootMotion = true;
				isGrounded = true;
			}
		}
	}

	public void Jump(){

		if (isGrounded & lionAnimator.GetFloat ("Forward")>.1f) {
			jumpUp=true;
			isGrounded = false;
			lionAnimator.applyRootMotion = false;
			lionAnimator.SetBool ("Landing",false);
			lionAnimator.SetTrigger ("Jump");		

			GetComponent<Rigidbody> ().AddForce ((transform.up - lionAnimator.GetFloat ("Forward") * transform.right) * jumpSpeed, ForceMode.Impulse);
			
		}
	}
	public void Attack(){
		lionAnimator.SetTrigger ("Attack");
	}
	public void Punch(){
		lionAnimator.SetTrigger ("Punch");
	}


	public void Move(float v,float h){
		lionAnimator.SetFloat ("Forward",v);
		lionAnimator.SetFloat ("Turn",h);
		
	}

}

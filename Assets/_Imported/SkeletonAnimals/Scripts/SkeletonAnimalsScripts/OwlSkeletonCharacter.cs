using UnityEngine;
using System.Collections;

public class OwlSkeletonCharacter : MonoBehaviour {
	public Animator owlAnimator;
	public float owlSpeed=1f;
	Rigidbody owlRigid;
	public bool isFlying=false;
	public float rotateSpeed=.2f;

	void Start () {
		owlAnimator = GetComponent<Animator> ();
		owlAnimator.speed = owlSpeed;
		owlRigid = GetComponent<Rigidbody> ();
	}	
	
	public void SpeedSet(float animSpeed){
		owlAnimator.speed = animSpeed;
	}
	
	public void Landing(){
		if (isFlying) {
			owlAnimator.SetTrigger ("Landing");
			owlAnimator.applyRootMotion = true;
			isFlying = false;
		}
	}
	
	public void Soar(){
		if(!isFlying){
			owlAnimator.SetTrigger ("Soar");
			owlAnimator.applyRootMotion = false;
			isFlying = true;
		}
	}
	
	public void Attack(){
		owlAnimator.SetTrigger ("Attack");
	}

	public void Hit(){
		owlAnimator.SetTrigger ("Hit");
	}

	public void Move(float v,float h){
		owlAnimator.SetFloat ("Forward",v);
		owlAnimator.SetFloat ("Turn",h);
		if(isFlying) {
			if (v > 0.1f) {
				owlRigid.AddForce ((transform.forward * 3f +transform.up *(Vector3.Dot( owlRigid.velocity,transform.forward)+9f))* v);
			}			
			owlRigid.AddTorque(transform.up*h*rotateSpeed);			
		}
	}

}

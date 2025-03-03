using UnityEngine;
using System.Collections;

public class StegosaurusSkeletonCharacter : MonoBehaviour {
	public Animator stegosaurusSkeletonAnimator;
	public float stegosaurusSkeletonSpeed=1f;
	
	void Start () {
		stegosaurusSkeletonAnimator = GetComponent<Animator> ();
		stegosaurusSkeletonAnimator.speed = stegosaurusSkeletonSpeed;
	}

	public void Eat(){
		stegosaurusSkeletonAnimator.SetTrigger ("Eat");
	}

	public void Attack(){
		stegosaurusSkeletonAnimator.SetTrigger ("Attack");
	}
	
	public void Hit(){
		stegosaurusSkeletonAnimator.SetTrigger ("Hit");
	}

	public void SitDown(){
		stegosaurusSkeletonAnimator.SetTrigger ("SitDown");
	}

	public void StandUp(){
		stegosaurusSkeletonAnimator.SetTrigger ("StandUp");
	}


	public void Move(float v,float h){
		stegosaurusSkeletonAnimator.SetFloat ("Forward",v);
		stegosaurusSkeletonAnimator.SetFloat ("Turn",h);	
	}
}

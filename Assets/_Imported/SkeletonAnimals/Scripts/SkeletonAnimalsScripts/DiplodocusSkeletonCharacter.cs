using UnityEngine;
using System.Collections;

public class DiplodocusSkeletonCharacter : MonoBehaviour {
	public Animator diplodocusSkeletonAnimator;
	public float diplodocusSkeletonSpeed=1f;
	
	void Start () {
		diplodocusSkeletonAnimator = GetComponent<Animator> ();
		diplodocusSkeletonAnimator.speed = diplodocusSkeletonSpeed;
	}

	
	public void Attack(){
		diplodocusSkeletonAnimator.SetTrigger ("Attack");
	}


	public void TailAttack(){
		diplodocusSkeletonAnimator.SetTrigger ("TailAttack");
	}

	public void Hit(){
		diplodocusSkeletonAnimator.SetTrigger ("Hit");
	}
	
	
	public void Move(float v,float h){
		diplodocusSkeletonAnimator.SetFloat ("Forward",v);
		diplodocusSkeletonAnimator.SetFloat ("Turn",h);	
	}
}

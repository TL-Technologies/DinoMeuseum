using UnityEngine;
using System.Collections;

public class ElephantSkeletonCharacter : MonoBehaviour {
	public Animator elephantSkeletonAnimator;
	public float elephantSkeletonSpeed=1f;
	
	void Start () {
		elephantSkeletonAnimator = GetComponent<Animator> ();
		elephantSkeletonAnimator.speed = elephantSkeletonSpeed;
	}

	
	public void Attack(){
		elephantSkeletonAnimator.SetTrigger ("Attack");
	}
	
	public void Hit(){
		elephantSkeletonAnimator.SetTrigger ("Hit");
	}
	
	public void SitDown(){
		elephantSkeletonAnimator.SetTrigger ("SitDown");
	}
	
	public void StandUp(){
		elephantSkeletonAnimator.SetTrigger ("StandUp");
	}
	
	
	
	public void Move(float v,float h){
		elephantSkeletonAnimator.SetFloat ("Forward",v);
		elephantSkeletonAnimator.SetFloat ("Turn",h);	
	}
}

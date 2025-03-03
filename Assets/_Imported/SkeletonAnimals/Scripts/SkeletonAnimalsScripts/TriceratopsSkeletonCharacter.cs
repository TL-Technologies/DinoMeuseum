using UnityEngine;
using System.Collections;

public class TriceratopsSkeletonCharacter : MonoBehaviour {

	public Animator triceratopsSkeletonAnimator;
	public float triceratopsSkeletonSpeed=1f;
	
	void Start () {
		triceratopsSkeletonAnimator = GetComponent<Animator> ();
		triceratopsSkeletonAnimator.speed = triceratopsSkeletonSpeed;
	}
	
	public void Eat(){
		triceratopsSkeletonAnimator.SetTrigger ("Eat");
	}
	
	public void Attack(){
		triceratopsSkeletonAnimator.SetTrigger ("Attack");
	}

	public void AttackLeft(){
		triceratopsSkeletonAnimator.SetTrigger ("AttackLeft");
	}
	
	public void AttackRight(){
		triceratopsSkeletonAnimator.SetTrigger ("AttackRight");
	}

	public void Hit(){
		triceratopsSkeletonAnimator.SetTrigger ("Hit");
	}
	
	public void SitDown(){
		triceratopsSkeletonAnimator.SetTrigger ("SitDown");
	}
	
	public void StandUp(){
		triceratopsSkeletonAnimator.SetTrigger ("StandUp");
	}
	
	
	public void Move(float v,float h){
		triceratopsSkeletonAnimator.SetFloat ("Forward",v);
		triceratopsSkeletonAnimator.SetFloat ("Turn",h);	
	}
}

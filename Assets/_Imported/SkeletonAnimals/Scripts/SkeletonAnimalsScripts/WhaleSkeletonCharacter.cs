using UnityEngine;
using System.Collections;

public class WhaleSkeletonCharacter : MonoBehaviour {
	public Animator whaleAnimator;
	Rigidbody whaleRigid;
	public float maxTurnSpeed=30000f;
	public float maxForwardSpeed=30000f;
	public float turnSpeed;
	public float upDownSpeed;
	public float forwardSpeed;

	void Start () {
		whaleAnimator = GetComponent<Animator> ();
		whaleRigid = GetComponent<Rigidbody> ();
	}

	void Update(){
		Move ();
	}

	public void Move(){
		whaleAnimator.SetFloat ("UpDown", upDownSpeed);
		whaleAnimator.SetFloat ("Turn", turnSpeed);
		whaleAnimator.SetFloat ("Forward", forwardSpeed);

		whaleRigid.AddTorque (transform.up*maxTurnSpeed*turnSpeed);
		whaleRigid.AddTorque (transform.right*maxTurnSpeed*(-upDownSpeed));
		whaleRigid.AddForce (transform.forward*maxForwardSpeed*forwardSpeed);
	}

	public void SpeedChange(float speed){
		forwardSpeed = speed;
	}

	public void Attack(){
		whaleAnimator.SetTrigger ("Attack");
	}


}

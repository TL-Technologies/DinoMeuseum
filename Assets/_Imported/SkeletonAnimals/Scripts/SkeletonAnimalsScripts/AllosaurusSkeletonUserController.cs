using UnityEngine;
using System.Collections;

public class AllosaurusSkeletonUserController : MonoBehaviour {

	AllosaurusSkeletonCharacter allosaurusCharacter;
	
	void Start () {
		allosaurusCharacter = GetComponent<AllosaurusSkeletonCharacter> ();
	}
	
	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			allosaurusCharacter.Jump();
		}
		
		if (Input.GetButtonDown ("Fire1")) {
			allosaurusCharacter.Attack();
		}

		if (Input.GetKeyDown(KeyCode.T)) {
			allosaurusCharacter.TailAttack();
		}
	}
	
	private void FixedUpdate()
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		allosaurusCharacter.Move (v,h);
	}
}

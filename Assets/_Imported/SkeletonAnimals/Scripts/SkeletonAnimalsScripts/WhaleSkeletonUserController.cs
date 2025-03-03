using UnityEngine;
using System.Collections;

public class WhaleSkeletonUserController : MonoBehaviour {
	WhaleSkeletonCharacter whaleCharacter;

	void Start () {
		whaleCharacter = GetComponent<WhaleSkeletonCharacter> ();
	}

	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			whaleCharacter.Attack();
		}


		whaleCharacter.turnSpeed=Input.GetAxis ("Horizontal");
		whaleCharacter.upDownSpeed= -Input.GetAxis ("Vertical");
	}
}

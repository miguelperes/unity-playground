using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public CharacterController2D controller;
		bool jump;
		bool longJump;
	
	void Start () {
		jump = false;
		longJump = false;
	}
	
	private void Update () {
		handleJumpInput();
	}

	private void FixedUpdate() {
			if(jump)
				controller.jump();
			
			if(longJump)
				controller.longJump();	
	}

	private void handleJumpInput() {
		if(Input.GetButtonDown("Jump"))
			jump = true;
		
		if(Input.GetButton("Jump"))
			longJump = true;

		if(Input.GetButtonUp("Jump")) {
			jump = longJump = false;
		}
	}


}

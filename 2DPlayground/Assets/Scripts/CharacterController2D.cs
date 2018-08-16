using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour {
	[SerializeField] private float allegroVelocity = 5f;
	[SerializeField] private float allegroImpulse = 0.125f;
	[SerializeField] private Transform maxHeight;
	[SerializeField] private LayerMask groundReference;
	[SerializeField] private Transform transformToCheck;

	private bool isGrounded;
	private bool isJumping;
	private float originalJumpForce;
	Rigidbody2D rigidBody2D;

	private void Start () {
		rigidBody2D = GetComponent<Rigidbody2D>();
		isJumping = false;

		if(!transformToCheck)
			transformToCheck = gameObject.transform;
	}

	public void jump() {
		if(isGrounded) {
			isGrounded = false;
			isJumping = true;

			rigidBody2D.velocity = new Vector2(0f, allegroVelocity);
		}
	}

	public void longJump() {
		if(isJumping)
			if(gameObject.transform.position.y <= maxHeight.position.y) {
				Vector2 currentVelocity = rigidBody2D.velocity;
				rigidBody2D.velocity = new Vector2(currentVelocity.x, currentVelocity.y + allegroImpulse);
			}
	}


	private void OnCollisionEnter2D(Collision2D other) {
		int otherLayer = other.collider.gameObject.layer;

		if(isInLayer(groundReference, otherLayer))
			isGrounded = true;

	}

	private void OnCollisionExit2D(Collision2D other) {
		int otherLayer = other.collider.gameObject.layer;
		
		if(isInLayer(groundReference, otherLayer))
			isGrounded = false;
	}

	private bool isInLayer(LayerMask mask, int layer) {
		return mask == (mask | (1 << layer));
	}

	/* Alternative way to check if character is grounded, to be called in FixedUdpdate */
	private void checkIfGrounded() {
		isGrounded = false;

		// Position to be checked against ground position
		Vector2 positionToCheck = transformToCheck.position;

		Collider2D [] colliders = Physics2D.OverlapCircleAll(positionToCheck, 1f, groundReference);
		for (int i = 0; i < colliders.Length; i++) {
			if (colliders[i].gameObject != gameObject)
				isGrounded = true;
		}
	}
}

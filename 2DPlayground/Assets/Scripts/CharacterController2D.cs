using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour {
	[SerializeField] private float jumpForce = 1f;
	[SerializeField] private LayerMask groundReference;
	[SerializeField] private Collider2D characterCollider;

	private bool isGrounded;

	Rigidbody2D rigidBody2D;

	void Start () {
		rigidBody2D = GetComponent<Rigidbody2D>();
		characterCollider = GetComponent<Collider2D>();
	}

	void OnCollisionEnter2D(Collision2D other) {
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
}

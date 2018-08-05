using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour {
	[SerializeField] private float jumpForce = 1f;
	[SerializeField] private LayerMask groundReference;
	[SerializeField] private Transform groundCheck;

	private bool isGrounded;

	Rigidbody2D rigidBody2D;

	void Start () {
		rigidBody2D = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
		isGrounded = false;
	}
}

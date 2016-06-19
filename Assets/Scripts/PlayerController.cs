﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	float cameraHalfWidth;
	GameObject playerLeft, playerRight;
	Rigidbody2D myRigidBody, myLeftRigidBody, myRightRigidBody;

	void Start () {
		cameraHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
		playerLeft =  GameObject.Find("PlayerLeft");
		playerRight = GameObject.Find("PlayerRight");

		myRigidBody = GetComponent<Rigidbody2D>();
		myLeftRigidBody = playerLeft.GetComponent<Rigidbody2D>();
		myRightRigidBody = playerRight.GetComponent<Rigidbody2D>();

		playerLeft.transform.position = new Vector2(transform.position.x - 2*cameraHalfWidth, transform.position.y);
		playerRight.transform.position = new Vector2(transform.position.x + 2*cameraHalfWidth, transform.position.y);

		myRigidBody.gravityScale = 0;
		myLeftRigidBody.gravityScale = 0;
		myRightRigidBody.gravityScale = 0;
	}
		
	void Update () {
		LimitBoundary();

		float direction = Input.GetAxisRaw("Horizontal");
		transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
	}

	void LimitBoundary() {
		Vector2 tempPosition = transform.position;

		if(tempPosition.x < -cameraHalfWidth) tempPosition.x = cameraHalfWidth;
		else if(tempPosition.x > cameraHalfWidth) tempPosition.x = -cameraHalfWidth;

		transform.position = tempPosition;
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Destroy(gameObject);
	}
}

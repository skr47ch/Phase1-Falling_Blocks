using UnityEngine;
using System.Collections;

public class PlayerCollide : MonoBehaviour {

	PlayerController player;
	float cameraHalfWidth;


	void Start(){
		player = FindObjectOfType<PlayerController>();
		cameraHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
	}


	void OnTriggerEnter2D (Collider2D collider) {
		if(OnScreen())
			Destroy(player.gameObject);
	}

	bool OnScreen() {
		float left, right;
		bool boo;
		left = transform.position.x - transform.localScale.x/2;
		right = transform.position.x + transform.localScale.x/2;
		boo = (left > -cameraHalfWidth && left < cameraHalfWidth) || (right > -cameraHalfWidth && right < cameraHalfWidth);

		return boo;
	}
}

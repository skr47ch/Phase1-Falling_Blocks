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
		if(OnScreen()) {
			if(player.life <= 0) {
				Destroy(player.gameObject);
				Destroy(collider.gameObject);
			}
			else {
				player.life--;
				Destroy(collider.gameObject);
			}
		}
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

using UnityEngine;
using System.Collections;

public class PlayerCollide : MonoBehaviour {

	PlayerController player;


	void Start(){
		player = FindObjectOfType<PlayerController>();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		
		Destroy(player.gameObject);
	}
}

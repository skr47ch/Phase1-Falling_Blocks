using UnityEngine;
using System.Collections;

public class TouchControl : MonoBehaviour {

	PlayerController player;

	void Start() {
		player = FindObjectOfType<PlayerController>();
	}

	public void LeftTouchDown() {
		player.direction = -1;
		Debug.Log("Left");
//		player.Move(-1);
	}

	public void RightTouchDown() {
		player.direction = 1;
	}

	public void ReleaseTouch() {
		player.direction = 0;
		Debug.Log("Released");

	}

}

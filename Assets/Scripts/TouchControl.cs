using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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

	public void RestartCurrentScene() {
		int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
		Time.timeScale = 1;
	}

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUI : MonoBehaviour {

	public Text score, gameOver;
	public Image live1, live2, live3;
	PlayerController player;
	float seconds;
	string currentScore = null;
	public bool countScore;
	public float theTime;

	void Start () {
		player = FindObjectOfType<PlayerController>();
		gameOver.gameObject.SetActive(false);
		theTime = 0f;
	}
	

	void Update () {
		
		if(!player.dead) {
			theTime += Time.deltaTime;
			currentScore = theTime.ToString("F0");
			score.text = "Score : " + currentScore;
		}
		else {
			score.gameObject.SetActive(false);
			gameOver.gameObject.SetActive(true);
			gameOver.text = "YOU DEAD\n" + "Score : " + currentScore;
		}

		if(player.life == 2 && live3) {
			Destroy(live3.gameObject);
		}
		else if(player.life == 1 && live2) {
			Destroy(live2.gameObject);
		}
		else if(player.life == 0 && live1) {
			Destroy(live1.gameObject);
		}
	}
		
}

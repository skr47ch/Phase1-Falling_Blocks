using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUI : MonoBehaviour {

	Text score;
	float seconds;

	void Start () {
		score = GetComponent<Text>();
	}
	

	void Update () {
		score.text = "Score : " + Time.time.ToString("F0");
	}
		
}

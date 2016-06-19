using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour {

	public float speed;
	float scale;

	void Start () {
		scale = transform.localScale.x;
	}

	void Update () {
		if(transform.position.y < - (Camera.main.orthographicSize + scale)) Destroy(gameObject);
		else transform.Translate(Vector2.down * speed * Time.deltaTime);
	}
}

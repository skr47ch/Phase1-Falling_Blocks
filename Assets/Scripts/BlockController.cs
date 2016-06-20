using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour {

	public float speed;
	float cameraHalfWidth;
	GameObject blockLeft, blockRight;
	float scale;

	void Start () {
		cameraHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
		scale = transform.localScale.x;

		foreach(Transform child in transform) {
			if(child.name == "BlockLeft") {
				child.transform.position = new Vector2(transform.position.x - 2*cameraHalfWidth, transform.position.y);

			}
			if(child.name == "BlockRight") {
				child.transform.position = new Vector2(transform.position.x + 2*cameraHalfWidth, transform.position.y);
			}
		}
	}

	void Update () {
		if(transform.position.y < - (Camera.main.orthographicSize + scale)) Destroy(gameObject);
		else transform.Translate(Vector2.down * speed * Time.deltaTime);
	}
}

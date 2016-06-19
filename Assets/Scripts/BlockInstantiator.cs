using UnityEngine;
using System.Collections;

public class BlockInstantiator : MonoBehaviour {

	public GameObject blockPrefab;
	float cameraHalfWidth, cameraHalfHeight;
	public float rotationRange;
	public float spawnInterval;
	public float maxSize;
	public float speed;

	bool changeSpeed;
	float nextTime;

	void Start () {
		cameraHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
		cameraHalfHeight = Camera.main.orthographicSize;
		changeSpeed = true;
	}


	void Update () {
		if(Time.time > nextTime) {
			Vector2 spawnPosition = new Vector2(Random.Range(-cameraHalfWidth, cameraHalfWidth), cameraHalfHeight + maxSize);
			Vector3 spawnRotation = Vector3.forward * Random.Range(-rotationRange, rotationRange);
			float spawnScale = Random.Range(1, maxSize);

			GameObject spawn = (GameObject) Instantiate(blockPrefab, spawnPosition, Quaternion.Euler(spawnRotation));
			spawn.transform.localScale = Vector2.one * spawnScale;

			BlockController block = spawn.GetComponent<BlockController>();
			block.speed = Random.Range(speed-Random.Range(1, 3), speed);

			nextTime = Time.time + spawnInterval;
		}

		if(changeSpeed) StartCoroutine(IncreaseSpeed());
	}

	IEnumerator IncreaseSpeed(){
		changeSpeed = false;
		if (speed < 10f) speed += 1f;
		if(spawnInterval >= 0.4f) spawnInterval -= 0.3f;
		yield return new WaitForSeconds (10f);
		changeSpeed = true;
	}
}

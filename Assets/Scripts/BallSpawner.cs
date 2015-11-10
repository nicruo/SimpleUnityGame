using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour {

	public GameObject[] balls;

	public Text ballCountText;

	public float minSize = 5;
	public float maxSize = 20;

	private int ballCount = 0;

	private GameObject currentBall;
	
	void Start () {
		SpawnBall ();
	}

	private void SpawnBall()
	{
		var randomBall = balls[Random.Range(0,balls.Length)];
		currentBall = Instantiate (randomBall, transform.position, transform.rotation) as GameObject;
		var randomSize = Random.Range (minSize, maxSize);
		currentBall.transform.localScale = new Vector3 (randomSize, randomSize, randomSize);
		ballCount++;
	}

	void Update () {
		if (!currentBall.GetComponent<BallControl> ().InControl) {
			SpawnBall();
		}

		ballCountText.text = ballCount + " Balls";
	}
}
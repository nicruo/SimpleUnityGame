using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {

	public bool InControl = true;

	private Rigidbody rigidBody;

	public float MovementForce = 10;
	
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}

	void Update () {

		if (InControl) {

			var horizontal = Input.GetAxis("Horizontal");
			var vertical = Input.GetAxis("Vertical");

			rigidBody.AddForce(horizontal * MovementForce, 0 , vertical * MovementForce);

			if (Input.GetKey (KeyCode.R)) {
				Reset();
			}
		}

		if (transform.position.y <= -10)
			Reset ();
	}

	void Reset()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	void OnCollisionEnter(Collision collision)
	{
		InControl = false;
	}
}

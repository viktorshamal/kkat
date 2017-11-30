using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	public float speed = 1f;
	public Vector3 direction;

	private Vector3 destination;

	void Start() {
		destination = transform.position + direction;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (direction * speed * Time.deltaTime);
		if ((transform.position - destination).magnitude < 0.4f) {
			direction *= -1;
			destination = transform.position + direction;
		}
	}
}

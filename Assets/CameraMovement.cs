using UnityEngine;
using System.Collections;
using CnControls;

public class CameraMovement : MonoBehaviour {
	public float speedH = 2.0f;
	public float speedV = 2.0f;
	public float speed = 1f;


	private float yaw = 0.0f;
	private float pitch = 0.0f;

	void Update () {
		yaw = speedH * CnInputManager.GetAxis("Mouse X");
		pitch = speedV * CnInputManager.GetAxis("Mouse Y");

		print (yaw + ", " + pitch);

		Vector3 rot = new Vector3(0.0f, yaw, pitch);

		transform.RotateAround (transform.parent.position, rot, speed * 100f * Time.deltaTime);
	}
}

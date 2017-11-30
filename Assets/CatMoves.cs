using UnityEngine;
using System.Collections;
using CnControls;
using CustomJoystick;

[RequireComponent(typeof(CharacterController))]
public class CatMoves : MonoBehaviour {
	public float rotationsFart = 3.0f;

	Animation animation;

	public CollisionScript collisionScript;
	private Vector3 startingPosition;
	private Quaternion startingRotation;


	void Start() {
		animation = GetComponent<Animation> ();
		startingPosition = transform.position;
		startingRotation = transform.rotation;
	}
	
	public float speed = 6.0F;
	public float topSpeed = 12.0f;
	public float jumpSpeed = 8.0F;
	public float topJumpSpeed = 40f;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	void Update() {
		CharacterController controller = GetComponent<CharacterController>();

		if (controller.isGrounded) {
			moveDirection = new Vector3(0, 0, CnInputManager.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);

			if (collisionScript.inSpeedZone) {
				moveDirection *= topSpeed;
			} else {
				moveDirection *= speed;
			}

			if (CnInputManager.GetButton ("Jump")) {
				if (collisionScript.onTrampoline) {
					moveDirection.y = topJumpSpeed;
				} else {
					moveDirection.y = jumpSpeed;
				}
			}
		}
			
		float rotationLigeNu = CnInputManager.GetAxis ("Horizontal") * rotationsFart;
		transform.Rotate (0, rotationLigeNu, 0);

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		if(CnInputManager.GetButton("Reset")) {
			transform.position = collisionScript.lastCheckpointPosition;
		}

		CheckForAnimation ();
	}

	void CheckForAnimation(){
		if(CnInputManager.GetAxis ("Vertical") != 0) {
			animation.Play("Run");
		} else {
			animation.Play ("Idle");
		}
	}
} 

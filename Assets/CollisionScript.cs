using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {

	public bool onTrampoline = false;
	public bool inSpeedZone = false;

	public Vector3 lastCheckpointPosition;

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.CompareTag("Trampoline")) {
			onTrampoline = true;
			transform.parent.parent = col.gameObject.transform;
		}

		if(col.gameObject.CompareTag("Speedup")) {
			print("true");
			inSpeedZone = true;
		}
			
		if(col.gameObject.CompareTag("Elevator")) {
			transform.parent.parent = col.gameObject.transform.parent;
		}

		if(col.gameObject.CompareTag("Checkpoint")) {
			print ("Checkpoint");
			lastCheckpointPosition = col.gameObject.transform.position;
		}
	}

	void OnTriggerExit(Collider col) {
		if(col.gameObject.CompareTag("Trampoline")) {
			onTrampoline = false;
			transform.parent.parent = null;
		}

		if(col.gameObject.CompareTag("Speedup")) {
			inSpeedZone = false;
		}

		if(col.gameObject.CompareTag("Elevator")) {
			transform.parent.parent = null;
		}
	}
}

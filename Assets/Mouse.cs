using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {
	public Transform destination;

	// Use this for initialization
	void Start () {
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.destination = destination.position;
	}
}

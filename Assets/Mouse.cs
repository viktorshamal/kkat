using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {
	public Transform[] destinations;
	private int i = 0;
	UnityEngine.AI.NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		agent.destination = destinations[0].position;
	}

	void Update() {
		if(!agent.hasPath && i + 1 < destinations.Length  ) {
			i++;
			agent.destination = destinations[i].position;
		}
	}
}

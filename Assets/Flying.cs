using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour {
	// Use this for initialization
	public int riseSpeed = 4;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)) {
			Vector3 oldTransform = transform.position;
			transform.position = new Vector3(oldTransform.x, oldTransform.y + riseSpeed * Time.deltaTime, oldTransform.z);
		}
	}
}

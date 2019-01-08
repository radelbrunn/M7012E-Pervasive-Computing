using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Standard unity boilerplate for camera control
// Makes for a camera that follows the player from a set distance
// All credits to the built-in unity tutorials for this code
public class CameraControl : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	void LateUpdate () {
		transform.position = player.transform.position+offset;
	}
}

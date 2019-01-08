using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueScript : MonoBehaviour, iValue {

	public int value;

	// Use this for initialization
	void Start () {
		
	}

	public int GetValue() {
		return value;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used for debugging
public class DefaultSumListener : SumListener {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	override public void OnSumChanged(int old, int current) {
		Debug.Log("old="+old+", current="+current);
	} 
}
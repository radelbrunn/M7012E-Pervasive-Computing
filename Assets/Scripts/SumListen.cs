using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumListen : SumListener {
	public MathLevel level;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void OnSumChanged(int old, int current) {
		level.sumChanged(old, current);
	}
}

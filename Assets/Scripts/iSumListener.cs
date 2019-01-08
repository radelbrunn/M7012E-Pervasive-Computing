using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iSumListener {
	void OnSumChanged(int old, int current);
}

public abstract class SumListener : MonoBehaviour, iSumListener {
	public abstract void OnSumChanged(int old, int current);
}

public class DebugLogSumListener : SumListener {
	override public void OnSumChanged(int old, int current) {
		Debug.Log("old="+old+", current="+current);
	} 
}

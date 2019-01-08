using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILetters {
    string GetLetters();
}

public class Letters : MonoBehaviour, ILetters {

    public string content;

	// Use this for initialization
	void Start () {
		
	}

    public string GetLetters() {
        return content;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

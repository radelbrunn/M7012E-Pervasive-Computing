using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface for fetching letters of objects
public interface ILetters {
    string GetLetters();
}

// Unity does not allow assigning interfaces in the editor.
// Therefore, a skeleton MonoBehaviour class is provided.
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

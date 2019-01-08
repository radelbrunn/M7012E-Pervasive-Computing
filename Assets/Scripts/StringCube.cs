using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Cubes which may contain text for the spelling game
public class StringCube : MonoBehaviour, ILetters {
    public string content;
    private Vector3 initialPosition; // Used for resetting once the cube hits the floor

    public string GetLetters()
    {
        return this.getText();
    }

    // Use this for initialization
    void Start () {
        this.setText(content);
        Vector3 pos = this.transform.position;
        this.initialPosition = new Vector3(pos.x, pos.y, pos.z);
	}
	
	// Update is called once per frame
	void Update () {
        this.setText(content);
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Floor")
        {
            Debug.Log("Collision??");
            resetPosition();
        }
    }

    public string getText() {
        return this.content;
    }

    private void setText(string newText)
    {
        this.content = newText;
        Text[] texts = this.GetComponentsInChildren<Text>();
        foreach (Text text in texts)
        {
            text.text = newText;
        }
    }

    void resetPosition()
    {
        this.gameObject.transform.position = initialPosition;
    }
}

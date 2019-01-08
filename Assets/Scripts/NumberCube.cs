using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberCube : MonoBehaviour, iValue {
    public int number;
    private Vector3 initialPosition;

	// Sets the displayed number to number set in the scene and saves initial position.
	void Start () {
        setNumber(number);
        Vector3 pos = this.gameObject.transform.position;
        initialPosition = new Vector3(pos.x, pos.y, pos.z);
	}

	
	// Update is called once per frame
	void Update () 
    {

    }

    // If cube is dropped on the floor, then reset to initial position.
    void OnCollisionEnter (Collision col) {
        if(col.gameObject.name == "Floor") {
            resetPosition();
        }
    }

    public int getNumber() {
        return this.number;
    }

    public int GetValue() {
        return getNumber();
    }

    public void setNumber(int newNumber) {
        this.number = newNumber;
        this.setNumbers(newNumber);
    }

    private void setNumbers(int newNumber) {
        Text[] texts = this.GetComponentsInChildren<Text>();
            foreach (Text text in texts) {
                text.text = newNumber.ToString();
            }
    }

    void resetPosition() {
        this.gameObject.transform.position = initialPosition;
    }
}

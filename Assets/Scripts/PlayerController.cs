using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;

	private int count;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		count = 0;
		UpdateCountText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moverVeritcal = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moverVeritcal);

		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pick Up")) {
			count += 1;
			UpdateCountText();
			other.gameObject.SetActive(false);
			if (count >= 12) {
				winText.text = "You WIN!";
			}
		}
		Destroy(other.gameObject);
	}

	public void OnSumChanged(int old, int current) {
		if (current == 0 && old != 0) {
			gameObject.SetActive(false);
		}
	}

	void UpdateCountText() {
		countText.text = "Count: " + count.ToString();
	}
}

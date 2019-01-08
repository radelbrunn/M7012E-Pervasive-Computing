using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    public float startSeconds;
    public Text label;
    private float remaining;
    public bool paused;

    public void Reset() {
        resetTimer();
    }

    public void resetTimer() {
        remaining = startSeconds;
        updateLabel();
    }

    public string GetRemainingTimeFormatted() {
        int minutes = ((int)remaining) / 60;
        int seconds = ((int)remaining) % 60;
        return String.Format("{0}:{1}", minutes, seconds.ToString("D2"));
    }

    public void updateLabel() {
        if (label != null)
            label.text = GetRemainingTimeFormatted();
    }

	// Use this for initialization
	public void Start () {
        resetTimer();
	}

    public bool Expired() {
        return remaining <= 0;
    }

    public float GetRemaining() {
        return remaining;
    }
	
	// Update is called once per frame
	void Update () {
        if (!paused) {
            remaining -= Time.deltaTime;
            if (remaining < 0)
            {
                if (label != null)
                    label.text = ("Time's up! (TODO: Call some kind of listener)");
            }
            else
            {
                updateLabel();
            }
        }
	}
}

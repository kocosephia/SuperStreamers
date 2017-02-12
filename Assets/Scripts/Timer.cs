using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text timerText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float time = GameState.GetTimeRemaining ();

		int hours = (int)(time / 3600);
		time -= hours * 3600;
		int minutes = (int)(time / 60);
		time -= minutes * 60;
		int seconds = (int)time;


		timerText.text = hours + ":" + minutes + ":" + seconds;
	}
}

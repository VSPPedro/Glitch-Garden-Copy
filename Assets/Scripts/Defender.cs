using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

	private StarDisplay starDisplay;

	void Start()
	{
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
	}

	//Just a tag
	public void AddStarts(int amount) {
		Debug.Log ("Opa, add estrelas!");
		starDisplay.AddStars (amount);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text starText;
	private int stars;

	// Use this for initialization
	void Start () {
		stars = 0;
		starText = GetComponent<Text> ();
	}

	public void AddStars (int amount){
		stars += amount;
		UpdateDisplay ();
	}

	void UpdateDisplay(){
		starText.text = stars.ToString ();
	}
}

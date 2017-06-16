using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	private Text costText;

	public static GameObject selectedDefender;
	private Button[] buttonArray;

	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button> ();

		costText = GetComponentInChildren<Text> ();

		if (!costText) {Debug.Log ("The object " + name + " has no costText!");}

		costText.text = defenderPrefab.GetComponent<Defender> ().starCost.ToString ();
	}

	void OnMouseDown ()
	{
		foreach (Button thisButton in buttonArray) 
		{
			thisButton.GetComponent<SpriteRenderer> ().color = Color.black;
		}

		GetComponent<SpriteRenderer> ().color = Color.white;
		selectedDefender = defenderPrefab;
	}
}

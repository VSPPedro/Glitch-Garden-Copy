﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	private const string DEFENDER_PARENT_NAME =  "Defenders";

	public Camera myCamera;

	private Vector2 defenderPosition;
	private GameObject defenderParent;
	private StarDisplay starDisplay;

	void Start()
	{
		defenderParent = GameObject.Find (DEFENDER_PARENT_NAME);
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();

		if (!defenderParent) 
		{
			defenderParent = new GameObject (DEFENDER_PARENT_NAME);
		}
	}

	void OnMouseDown()
	{
		if (Button.selectedDefender) {
			defenderPosition = SnapToGrid (CalculateWorldPointOfMouseClick ());
			GameObject defender = Button.selectedDefender;
			int defenderCost = defender.GetComponent<Defender> ().starCost;

			if (starDisplay.UseStars (defenderCost) == StarDisplay.Status.SUCCESS) {
				GameObject newDefender = Instantiate (defender, defenderPosition, Quaternion.identity);
				newDefender.transform.parent = defenderParent.transform;
			} else {
				Debug.Log ("Insufficient stars to spwan!");
			}
		} else {
			Debug.LogWarning ("Nenhum defensor foi selecionado!");
		}

	}

	Vector2 CalculateWorldPointOfMouseClick ()
	{
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 wordPosition = myCamera.ScreenToWorldPoint (weirdTriplet);

		return wordPosition;
	}

	Vector2 SnapToGrid (Vector2 rawWorldPosition)
	{
		float newX = Mathf.RoundToInt (rawWorldPosition.x);
		float newY = Mathf.RoundToInt (rawWorldPosition.y);

		return new Vector2 (newX, newY);
	}
}

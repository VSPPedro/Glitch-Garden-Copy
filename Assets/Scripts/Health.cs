﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float health = 100f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DealDamage(float damage)
	{
		health -= damage;

		if (health <= 0) 
		{
			DestroyObject ();
		}

	}

	public void DestroyObject()
	{
		Debug.Log ("Eu, " + name + ", fui destruido! Meu hp: " + health);
		Destroy (gameObject);
	}
}

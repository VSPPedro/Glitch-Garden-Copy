using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

	private GameObject currentTarget;
	private float currentSpeed;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D()
	{
		Debug.Log (name + "trigger enter");
	}

	public void setSpeed(float speed)
	{
		currentSpeed = speed;
	}

	public void StrikeCurrentTarget(float damage)
	{
		
	}

	public void Attack(GameObject obj)
	{
		currentTarget = obj;
	}
}

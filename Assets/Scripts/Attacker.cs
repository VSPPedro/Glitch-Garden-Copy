using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

	private GameObject currentTarget;
	private float currentSpeed;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);

		if (currentTarget)
			anim.SetBool ("isAttacking", false);
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
		if (currentTarget) 
		{
			Health health = currentTarget.GetComponent<Health> ();

			if (health) 
			{
				health.DealDamage (damage);
			}
		}
	}

	public void Attack(GameObject obj)
	{
		currentTarget = obj;
	}
}

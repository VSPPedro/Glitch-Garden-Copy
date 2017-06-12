using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	private const string PROJECTILE_PARENT_NAME =  "Projectile";

	public GameObject projectile, gun;

	private Animator anim;
	private Spawner myLaneSpawner;
	private GameObject projectileParent;

	void Start()
	{
		anim = GameObject.FindObjectOfType<Animator> ();

		// Creates a parente if necessary
		projectileParent = GameObject.Find (PROJECTILE_PARENT_NAME);
		if (!projectileParent) 
		{
			projectileParent = new GameObject (PROJECTILE_PARENT_NAME);
		}

		SetMyLaneSpawne ();
	}

	void Update()
	{
		if (IsAttackerAheadInLane ()) {
			anim.SetBool ("isAttacking", true);
		} else {
			anim.SetBool ("isAttacking", false);
		}
	}

	private void SetMyLaneSpawne()
	{
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> ();

		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}

		Debug.LogError ("Cant find spawnner!!");
	}

	private bool IsAttackerAheadInLane ()
	{
		// Exit if no attackers in lane
		if (myLaneSpawner.transform.childCount <= 0) 
		{
			return false;
		}

		// If there are attacker, are they ahead?
		foreach (Transform attacker in myLaneSpawner.transform)
		{
			if (attacker.transform.position.x > transform.position.x) 
			{
				return true;
			}
		}

		return false;
	}

	private void Fire()
	{
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	private const string PROJECTILE_PARENT_NAME =  "Projectile";

	public GameObject projectile, gun;

	private GameObject projectileParent;

	void Start()
	{
		projectileParent = GameObject.Find (PROJECTILE_PARENT_NAME);

		if (!projectileParent) 
		{
			projectileParent = new GameObject (PROJECTILE_PARENT_NAME);
		}
	}

	private void Fire()
	{
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}

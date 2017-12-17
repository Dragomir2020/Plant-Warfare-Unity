using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	/// <summary>
	/// The projectile.
	/// </summary>
	public GameObject projectile;

	/// <summary>
	/// The projectile parent.
	/// </summary>
	private GameObject projectileParent;

	public GameObject projectileSpawn;
	/// <summary>
	/// Searches for the projectile parent.
	/// </summary>
	void Start()
	{
		projectileParent = GameObject.Find("Projectiles");

		if (!projectileParent)
		{
			Debug.LogWarning("Create Projectiles GameObject for projectiles");
		}

		projectileSpawn = transform.GetChild(1).gameObject;

		if (!projectileSpawn || projectileSpawn.name != "ProjectileSpawn")
		{
			Debug.LogWarning("Create ProjectileSpawn child game object for game object with shooter attached.");
		}

	}

	/// <summary>
	/// Fires the given projectile.
	/// </summary>
	private void Fire()
	{
		GameObject newProjectile = Instantiate(projectile) as GameObject;

		// Sets parent of projectile in scene heirarchy
		if (projectileParent)
		{
			newProjectile.transform.SetParent(projectileParent.transform);
		}

		// Sets position of projectile to shoot from
		if (projectileSpawn)
		{
			newProjectile.transform.position = projectileSpawn.transform.position;
		}

	}
}

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

	/// <summary>
	/// The projectile spawn.
	/// </summary>
	public GameObject projectileSpawn;

	/// <summary>
	/// The enemy animator.
	/// </summary>
	private Animator enemyAnimator;

	/// <summary>
	/// My lane spawner.
	/// </summary>
	private EnemySpawner myLaneSpawner;

	/// <summary>
	/// Searches for the projectile parent.
	/// </summary>
	void Start()
	{
		projectileParent = GameObject.Find("Projectiles");

		// Create Projectiles GO for projectileParent if DNE
		if (!projectileParent)
		{
			projectileParent = new GameObject();
			projectileParent.name = "Projectiles";
		}

		projectileSpawn = transform.GetChild(1).gameObject;

		// Throws warning if ProjectileSpawn is not child to Projectile
		if (!projectileSpawn || projectileSpawn.name != "ProjectileSpawn")
		{
			Debug.LogWarning("Create ProjectileSpawn child game object for game object with shooter attached.");
		}

		enemyAnimator = GameObject.FindObjectOfType<Animator>();

		SetMyLaneSpawner();
	}

	/// <summary>
	/// Enables defender if attacker is in lane
	/// </summary>
	void Update()
	{
		// Updates animation every frame whether enemy is found in lane ahead of defender
		if (IsAttackerAheadInLane())
		{
			enemyAnimator.SetBool("isAttacking", true);
		}
		else {
			enemyAnimator.SetBool("isAttacking", false);
		}
	}

	private void SetMyLaneSpawner()
	{
		EnemySpawner[] spawnerArray = GameObject.FindObjectsOfType<EnemySpawner>();

		foreach (EnemySpawner spawn in spawnerArray)
		{
			// Check whether shooter is in same lane as spawner
			// Floating point precision affects ==
			if (spawn.transform.position.y == transform.position.y)
			{
				myLaneSpawner = spawn;
				return;
			}
		}

		Debug.LogError(name + " can't find spawner in lane.");
	}

	private bool IsAttackerAheadInLane()
	{
		// Exits if no attackers are in lane
		if (myLaneSpawner.transform.childCount <= 0)
		{
			return false;
		}

		// If there are attackers, are they ahead
		foreach (Transform attackers in myLaneSpawner.transform)
		{
			//Checks whether enemies x coordinate is in front of defender
			if ((attackers.transform.position.x + 12) > transform.position.x)
			{
				return true;
			}
		}

		// Attackers in lane, but behind us
		return false;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	/// <summary>
	/// Array of all the enemies prefab objects.
	/// </summary>
	public GameObject[] attackerPrefabArray;
	
	/// <summary>
	/// Spawning logic
	/// </summary>
	void Update () {
		foreach (GameObject myAttacker in attackerPrefabArray)
		{
			if (IsTimeToSpawn(myAttacker))
			{
				Spawner(myAttacker);
			}
		}
	}

	/// <summary>
	/// Returns true if it is time for the lane to spawn enemy
	/// </summary>
	/// <returns><c>true</c>, if time to spawn was ised, <c>false</c> otherwise.</returns>
	/// <param name="attackerGO">Attacker go.</param>
	private bool IsTimeToSpawn(GameObject attackerGO)
	{
		Attackers att = attackerGO.GetComponent<Attackers>();

		float meanSpawnDelay = att.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay)
		{
			Debug.LogWarning("Spawn rate capped by frame rate");
		}

		float threshold = spawnsPerSecond * Time.deltaTime / 5;

		if (Random.value < threshold)
		{
			return true;
		}
		else {
			return false;
		}

	}

	/// <summary>
	/// Spawner the specified attackerGO.
	/// </summary>
	/// <param name="attackerGO">Attacker go.</param>
	private void Spawner(GameObject attackerGO)
	{
		GameObject attacker = Instantiate(attackerGO) as GameObject;
		attacker.transform.parent = transform;
		attacker.transform.position = transform.position;
	}
}

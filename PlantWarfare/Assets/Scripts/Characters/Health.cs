using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	/// <summary>
	/// The health.
	/// </summary>
	public float health = 100f;

	/// <summary>
	/// Deals the damage.
	/// </summary>
	/// <param name="damage">Damage.</param>
	public void DealDamage(float damage)
	{
		if (health - damage > 0)
		{
			health -= damage;
		}
		else {
			DestroyObject();
		}
	}

	/// <summary>
	/// Destroies the object.
	/// </summary>
	public void DestroyObject()
	{
		DestroyObject(this.gameObject);
	}
}

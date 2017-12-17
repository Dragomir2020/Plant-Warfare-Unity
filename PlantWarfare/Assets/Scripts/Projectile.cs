using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	/// <summary>
	/// The transform speed.
	/// </summary>
	public float transformSpeed = 2f;

	/// <summary>
	/// The damage.
	/// </summary>
	public float damage = 25f;

	/// <summary>
	/// The rotation speed.
	/// </summary>
	public float rotationSpeed = 300f;

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
		// Translate projectile
		transform.Translate(Vector3.right * transformSpeed * Time.deltaTime);
		// Rotate projectile
		transform.GetChild(0).Rotate(new Vector3(0f, 0f, -rotationSpeed * Time.deltaTime));
	}

	/// <summary>
	/// Ons the trigger enter2 d.
	/// </summary>
	/// <param name="collider">Collider.</param>
	void OnTriggerEnter2D(Collider2D collider)
	{
		//True when collides with attacker
		//Having scripts for differnt objects allows us not to use collision matrix
		if (collider.gameObject.GetComponent<Attackers>())
		{
			DestroyProjectile();
		}
	}

	/// <summary>
	/// Destroies the projectile.
	/// </summary>
	public void DestroyProjectile()
	{
		DestroyObject(this.gameObject);
	}

}

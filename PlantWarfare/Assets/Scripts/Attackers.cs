using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Attackers : MonoBehaviour {

	/// <summary>
	/// The current speed.
	/// </summary>
	[Range(-1f, 1.5f)]
	public float currentSpeed;

	/// <summary>
	/// The current target.
	/// </summary>
	private GameObject currentTarget;

	/// <summary>
	/// The animator of the current object.
	/// </summary>
	private Animator animator;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		animator = GetComponent<Animator>();
	}

	/// <summary>
	/// Move enemy every frame to the left
	/// </summary>
	void Update () {
		// Move enemy in direction
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		//Resumes walking if current target is destroyed
		if (!currentTarget)
		{
			animator.SetBool("isAttacking", false);
		}
	}

	/// <summary>
	/// Called when box collider trigger is activated
	/// </summary>
	void OnTriggerEnter2D(Collider2D collider)
	{
		//True when collides with attacker
		//Having scripts for differnt objects allows us not to use collision matrix
		if (collider.gameObject.GetComponent<Projectile>())
		{
			Health attackerHealth = GetComponent<Health>();
			if (attackerHealth)
			{
				// Deal projectile damage to attacker
				attackerHealth.DealDamage(collider.gameObject.GetComponent<Projectile>().damage);
			}
			else {
				DestroyObject(this.gameObject);
			}
		}
	}

	/// <summary>
	/// Sets the current speed of the attacker movement
	/// </summary>
	/// <param name="speed">Speed.</param>
	public void SetCurrentSpeed(float speed)
	{
		currentSpeed = speed;
	}

	/// <summary>
	/// Strikes the current target and deals damage every animation loop.
	/// </summary>
	/// <param name="damage">Damage.</param>
	public void StrikeCurrentTarget(float damage)
	{
		if (currentTarget)
		{
			Health health = currentTarget.GetComponent<Health>();
			if (health)
			{
				health.DealDamage(damage);
			}
		}
	}

	/// <summary>
	/// Called when target is engaged.
	/// </summary>
	/// <param name="target">Target.</param>
	public void Attack(GameObject target)
	{
		currentTarget = target;
	}

}

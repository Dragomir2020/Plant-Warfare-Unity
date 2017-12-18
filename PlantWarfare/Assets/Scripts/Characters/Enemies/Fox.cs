using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tells Unity Attacker component is required for this class
[RequireComponent (typeof (Attackers))]
public class Fox : MonoBehaviour {

	private Animator anim;
	private Attackers attacker;

	void Start()
	{
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attackers>();
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		GameObject obj = collider.gameObject;

		// Leave method if not colliding with defender
		if (!obj.GetComponent<Defenders>())
		{
			return;
		}

		//Trigger jump animation
		if (obj.GetComponent<Stone>())
		{
			anim.SetTrigger("jumpTrigger");
		}
		else 
		{
			// Set's animation to attacking
			anim.SetBool("isAttacking", true);
			attacker.Attack(obj);
		}
	}
}

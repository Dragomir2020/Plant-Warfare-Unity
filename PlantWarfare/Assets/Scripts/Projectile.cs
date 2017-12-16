using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float transformSpeed = 2f;
	public float damage = 25f;
	public float rotationSpeed = 1000f;


	void Update () {
		// Translate projectile
		transform.parent.Translate(Vector3.right * transformSpeed * Time.deltaTime);
		// Rotate projectile
		transform.Rotate(new Vector3(0f, 0f, -rotationSpeed * Time.deltaTime));
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// Triggered when defender is hit
	/// </summary>
	void OnTriggerEnter2D()
	{
		Debug.LogWarning(name + " Triggered");
	}
}

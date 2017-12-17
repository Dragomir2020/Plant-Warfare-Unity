using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	/// <summary>
	/// The button array for the different defenders.
	/// </summary>
	private Button[] buttonArray;

	/// <summary>
	/// Only should have one selected defender across all instances.
	/// </summary>
	public static GameObject selectedDefender;

	/// <summary>
	/// Unique defender prefab attached for each type of defender.
	/// </summary>
	public GameObject defenderPrefab;

	/// <summary>
	/// Finds components.
	/// </summary>
	void Start()
	{
		// Finds all objects with button component attached
		buttonArray = GameObject.FindObjectsOfType<Button>();
	}

	/// <summary>
	/// Triggered when button is pressed.
	/// </summary>
	void OnMouseDown()
	{
		foreach (Button thisbutton in buttonArray)
		{
			thisbutton.GetComponent<SpriteRenderer>().color = Color.black;
		}

		SpriteRenderer ren = GetComponent<SpriteRenderer>();

		if (ren)
		{
			// Can also use color.white
			ren.color = new Color(255f, 255f, 255f);
		}

		// Set the static defender to instance prefab
		selectedDefender = defenderPrefab;

	}


}

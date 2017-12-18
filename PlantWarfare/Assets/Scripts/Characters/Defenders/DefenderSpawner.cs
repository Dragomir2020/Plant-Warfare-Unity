using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	/// <summary>
	/// The defender spawner.
	/// </summary>
	private GameObject defenderSpawner;

	/// <summary>
	/// The world coordinates.
	/// </summary>
	private Vector2 worldCoordinates;

	/// <summary>
	/// Camera found in scene or created.
	/// </summary>
	private GameObject myCamera;

	/// <summary>
	/// Created game object to spawn defenders inside of
	/// </summary>
	void Start()
	{
		defenderSpawner = new GameObject();
		defenderSpawner.name = "Defenders";

		myCamera = GameObject.Find("Game Camera");
		if (!myCamera)
		{
			// Create camera if it doesn't exist
			myCamera = new GameObject();
			myCamera.name = "Game Camera";
			myCamera.AddComponent<Camera>();

			// Set transform for camera
			myCamera.transform.position = new Vector3(5f, 3f, -10f);

			// Set camera to orthographic and size or camera
			Camera cam = myCamera.GetComponent<Camera>();
			cam.orthographic = true;
			cam.orthographicSize = 3.375f;
		}
	}

	/// <summary>
	/// Called when CoreGame object is tapped or clicked.
	/// </summary>
	void OnMouseDown()
	{
		worldCoordinates = CalculateWorldPosition();
		SpawnDefender();
	}

	/// <summary>
	/// Spawns the defender.
	/// </summary>
	private void SpawnDefender()
	{
		// Gets static defender and then creates new one parented to Defenders GO
		GameObject selDefender = Button.selectedDefender;

		if (selDefender)
		{
			//Check whether defender already exists there
			Vector2 snappedCoordinates = SnapToGrid(worldCoordinates);
			Collider[] hitColliders = Physics.OverlapSphere( new Vector3(snappedCoordinates.x,snappedCoordinates.y, 0f), 0.3f);

			foreach (Collider col in hitColliders)
			{
				Defenders def = col.gameObject.GetComponent<Defenders>();
				if (def)
				{
					return;
				}
			}

			GameObject newDefender = Instantiate(selDefender) as GameObject;
			newDefender.transform.SetParent(defenderSpawner.transform);

			// Set Position of defender
			newDefender.transform.position = snappedCoordinates;
		}
	}

	/// <summary>
	/// Calculates the world position of given mouse position.
	/// </summary>
	/// <returns>The world position.</returns>
	private Vector2 CalculateWorldPosition()
	{
		// Get mouse coordinates and convert them to world position for placing in grid
		Vector3 coord = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
		Vector2 world = myCamera.GetComponent<Camera>().ScreenToWorldPoint(coord);

		return world;
	}

	/// <summary>
	/// Snaps to defenders world position to grid.
	/// </summary>
	/// <returns>The to grid.</returns>
	/// <param name="rawWorldPos">Raw world position.</param>
	private Vector2 SnapToGrid(Vector2 rawWorldPos)
	{
		return new Vector2(Mathf.Round(rawWorldPos.x), Mathf.Round(rawWorldPos.y));
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

	private MusicManager musicManager;

	// Find Music manager and set volume
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
	}

}

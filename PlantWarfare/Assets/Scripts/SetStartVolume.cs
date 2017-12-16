using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

	private MusicManager musicManager;

	/// <summary>
	///  Find Music manager and set volume when scene is loaded
	/// </summary>
	void Start()
	{
		musicManager = FindObjectOfType<MusicManager>();
		if (!musicManager)
		{
			Debug.LogWarning("No music manager found in start scene so can't set volume");
		}
		else {
			float volume = PlayerPrefsManager.GetMasterVolume();
			musicManager.ChangeVolume(volume);
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OptionsController : MonoBehaviour {

	/// <summary>
	/// The volume slider.
	/// </summary>
	public Slider VolumeSlider;
	/// <summary>
	/// The difficulty slider.
	/// </summary>
	public Slider DifficultySlider;
	/// <summary>
	/// The music manager.
	/// </summary>
	private MusicManager musicManager;
	/// <summary>
	/// The level manager.
	/// </summary>
	public LevelManager levelManager;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		//Will only exists if game is started from splash screen scene
		if (musicManager != null) {

		}
		try{
			VolumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
		} catch(Exception e){
			Debug.LogError ("Error: " + e.ToString ());
		}
		try{
			DifficultySlider.value = PlayerPrefsManager.GetDifficulty();
		} catch(Exception e){
			Debug.LogError ("Error: " + e.ToString ());
		}
	}

	/// <summary>
	/// Saves and exits after setting player preferences.
	/// </summary>
	public void SaveAndExit(){
		if (VolumeSlider != null) {
			PlayerPrefsManager.SetMasterVolume (VolumeSlider.value);
		} else {
			Debug.LogError ("Attach volume slider in inspector");
		}
		if (DifficultySlider != null) {
			PlayerPrefsManager.SetDifficulty (DifficultySlider.value);
		} else {
			Debug.LogError ("Attach difficulty slider in inspector");
		}
		if (levelManager != null) {
			levelManager.LoadLevel ("StartMenu");
		} else {
			Debug.LogError ("Attach level manager in inspector");
		}
	}

}

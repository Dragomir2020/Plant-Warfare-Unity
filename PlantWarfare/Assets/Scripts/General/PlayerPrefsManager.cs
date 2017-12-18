using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

	/// <summary>
	/// The master volume key.
	/// </summary>
	private const string MASTER_VOLUME_KEY = "master_volume";
	/// <summary>
	/// The difficulty key.
	/// </summary>
	private const string DIFFICULTY_KEY = "difficulty";
	/// <summary>
	/// The level key.
	/// </summary>
	private const string LEVEL_KEY = "level_unlocked_";

	/// <summary>
	/// Sets the master volume.
	/// </summary>
	/// <param name="volume">Volume.</param>
	public static void SetMasterVolume(float volume){
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Master volume must be between 0f and 1f");
		}
	}

	/// <summary>
	/// Gets the master volume.
	/// </summary>
	/// <returns>The master volume.</returns>
	public static float GetMasterVolume(){
		if (PlayerPrefs.HasKey (MASTER_VOLUME_KEY)) {
			return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
		} else {
			Debug.LogWarning ("Must set master volume before getting it");
		}
		return 0f;
	}

	/// <summary>
	/// Unlocks the level.
	/// </summary>
	/// <param name="level">Level.</param>
	public static void UnlockLevel(int level){
		if (level <= Application.levelCount - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (), 1); //Use 1 for true
		} else {
			Debug.LogError ("Trying to unlock level no in build order/settings");
		}
	}

	/// <summary>
	/// Determines if level is locked.
	/// </summary>
	/// <returns><c>true</c> if given level is unlocked; otherwise, <c>false</c>.</returns>
	/// <param name="level">Level.</param>
	public static bool IsLevelLocked(int level){
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ());
		bool isLevelUnlocked = (levelValue == 1);

		if(level <= Application.levelCount - 1){
			return isLevelUnlocked;
		} else {
			Debug.LogError ("Trying to query level not in build order/settings");
		}
		return false;
	}

	/// <summary>
	/// Gets the difficulty.
	/// </summary>
	/// <returns>The difficulty.</returns>
	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}

	/// <summary>
	/// Sets the difficulty from 1 to 3.
	/// </summary>
	/// <param name="difficulty">Difficulty.</param>
	public static void SetDifficulty(float difficulty){
		if (difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError ("Difficulty must be between 1f and 3f");
		}
	}

}

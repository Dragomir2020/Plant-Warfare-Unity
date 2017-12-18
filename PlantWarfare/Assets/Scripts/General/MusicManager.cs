using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	/// <summary>
	/// Array of the Audio Clips for each level.
	/// </summary>
	public AudioClip[] levelMusicChangeArray;
	/// <summary>
	/// The audio source used to play the audio clip.
	/// </summary>
	private AudioSource audioSource;

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake(){
		DontDestroyOnLoad (this);
	}

	/// <summary>
	/// Start this instance.
	/// </summary>//
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	/// <summary>
	/// Loads new music for each level
	/// </summary>
	/// <param name="level">Level.</param>
	private void OnLevelWasLoaded(int level){
		AudioClip music = levelMusicChangeArray [level];
		//If music is attached
		if (music != null){
			audioSource.clip = music;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}

	/// <summary>
	/// Changes the volume.
	/// </summary>
	/// <param name="volume">Volume.</param>
	public void ChangeVolume(float volume){
		audioSource.volume = volume;
	}
}

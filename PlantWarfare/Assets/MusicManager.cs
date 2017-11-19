using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	void Awake(){
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	/// <summary>
	/// Loads new music for each level
	/// </summary>
	/// <param name="level">Level.</param>
	void OnLevelWasLoaded(int level){
		AudioClip music = levelMusicChangeArray [level];
		//If music is attached in 
		if (music != null){
			audioSource.clip = music;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}
}

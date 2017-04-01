using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	void Awake(){
		DontDestroyOnLoad (gameObject);
	}

	void Start(){
		audioSource = gameObject.GetComponent<AudioSource> ();
	}

	void OnLevelWasLoaded(int level){

		AudioClip thisLevelMusic = levelMusicChangeArray [level];

		if (thisLevelMusic) {
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}
}

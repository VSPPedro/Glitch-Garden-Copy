using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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

	/*void OnLevelWasLoaded(int level){

		AudioClip thisLevelMusic = levelMusicChangeArray [level];

		if (thisLevelMusic) {
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}*/

	void OnEnable()
	{
		//Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnDisable()
	{
		//Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
	{
		AudioClip thisLevelMusic = levelMusicChangeArray [scene.buildIndex];

		if (thisLevelMusic) {
			audioSource.clip = thisLevelMusic;

			if (scene.buildIndex != 6) {
				audioSource.loop = true;
			} else {
				audioSource.loop = false;
			}
					
		
			audioSource.Play ();
		}

		Debug.Log("Level Loaded");
		Debug.Log(scene.name);
		Debug.Log(mode);
	}
}

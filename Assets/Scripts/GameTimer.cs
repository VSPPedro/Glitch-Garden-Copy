using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float levelSeconds;

	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winLabel;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		FindYouWin ();
	}

	void FindYouWin ()
	{
		winLabel = GameObject.Find ("You Win");
		if (!winLabel) {
			Debug.LogWarning ("Please create a You Win Object!");
		} else {
			winLabel.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelSeconds;

		bool timesIsup = (Time.timeSinceLevelLoad >= levelSeconds);

		if (timesIsup && !isEndOfLevel) {
			HandleWinCondition ();
		}
	}

	void HandleWinCondition ()
	{
		DestroyAllTaggedObjects ();
		audioSource.Play ();
		winLabel.SetActive (true);
		Invoke ("LoadNextLevel", audioSource.clip.length);
		isEndOfLevel = true;
	}

	void DestroyAllTaggedObjects ()
	{
		//DestroyOnWin
		GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("DestroyOnWin");

		foreach (GameObject taggedObject in taggedObjectArray) {
			Destroy (taggedObject);
		}
	}

	void LoadNextLevel(){
		levelManager.LoadNextLevel ();
	}
}

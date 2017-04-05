using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print (PlayerPrefsManager.GetMasterVolume ());
		PlayerPrefsManager.SetMasterVolume (0.3f);
		print (PlayerPrefsManager.GetMasterVolume ());

		print (PlayerPrefsManager.isLevelUnlocked (2));
		PlayerPrefsManager.UnLockLevel (2);
		print (PlayerPrefsManager.isLevelUnlocked (2));

		print (PlayerPrefsManager.GetDifficulty ());
		PlayerPrefsManager.SetDifficulty(2f);
		print (PlayerPrefsManager.GetDifficulty ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

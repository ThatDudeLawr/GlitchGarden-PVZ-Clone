using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

	private MusicPlayer musicManager;
	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicPlayer>();
		Debug.Log ("Found Music Manager");
		if(musicManager){
			float volume = PlayerPrefsManager.GetMasterVolume();
			musicManager.ChangeVolume(volume);
		} else{
			Debug.LogError("No music Player found.");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {
	
	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;
	private MusicPlayer musicManager;
	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicPlayer>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.ChangeVolume(volumeSlider.value);
	}

	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty((int)difficultySlider.value);
		levelManager.LoadLevel("01a Start");
	}

	public void SetDefaults(){
		volumeSlider.value = 0.75f;
		difficultySlider.value = 2;
	}
}

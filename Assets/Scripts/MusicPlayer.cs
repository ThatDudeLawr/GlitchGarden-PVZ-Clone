using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;
	private AudioClip thisLevelMusic;

	void Awake () {
		if(GameObject.FindGameObjectsWithTag("Music Player").Length > 1){
			Destroy(gameObject);
		}
		DontDestroyOnLoad (gameObject);
		Debug.Log("Don't destroy on load: " + name);
	}

	void Start(){
		thisLevelMusic = levelMusicChangeArray[1];
		audioSource = gameObject.GetComponent<AudioSource>();
		thisLevelMusic = levelMusicChangeArray[SceneManager.GetActiveScene().buildIndex];
		audioSource.clip=thisLevelMusic;
		audioSource.loop = true;
		audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void OnEnable() {
	SceneManager.sceneLoaded += OnSceneLoaded; // subscribe
	}
	private void OnDisable() {
	SceneManager.sceneLoaded -= OnSceneLoaded; //unsubscribe
	}
	// The replacement for the OnLevelWasLoaded method. You may name it as you want. Make sure to subscribe/unsubscribe the correct method name (see above)
	private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) {
		thisLevelMusic = levelMusicChangeArray[SceneManager.GetActiveScene().buildIndex];
		if(thisLevelMusic){
			audioSource.clip = thisLevelMusic;
			audioSource.Play();
		}
		if(SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 5){
			audioSource.loop = false;
		}else{
			audioSource.loop = true;
		}
	}
	public void ChangeVolume(float volume){
		audioSource.volume = volume;
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public float autoLoadNextLevelDelay;
	public void LoadLevel(string name){
		Debug.Log("Level load is requested for " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Debug.Log("Quit request has been sent");
		Application.Quit();
	}

	public void LoadNextLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	void Start(){
		if(autoLoadNextLevelDelay != 0){
			AutoLoadNextLevel();
		}
	}
	public void AutoLoadNextLevel(){
		Invoke("LoadNextLevel",autoLoadNextLevelDelay);
	}


}
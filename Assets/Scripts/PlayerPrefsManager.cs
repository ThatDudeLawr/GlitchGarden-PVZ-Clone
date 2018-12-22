using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume (float volume){
		if(volume >= 0f && volume <= 1f){
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY,volume);
		}else{
			Debug.LogError("Master Volume out of range (0-1).");
		}
	}

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}

	public static void UnlockLevel(int level){
		if (level <= SceneManager.sceneCountInBuildSettings - 1){
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
		} else{
			Debug.LogError("Level number is exceeding the build settings number of scenes");
		}
	} 
	public static bool IsLevelUnlocked(int level){
		int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue == 1);
		if (level <= SceneManager.sceneCountInBuildSettings - 1){
			return isLevelUnlocked;
		}else{
			Debug.LogError("Level number is exceeding the build settings number of scenes");
			return false;
		}
	}

	public static void SetDifficulty(int value){
		if( value >= 1 && value <= 3 ){
			PlayerPrefs.SetInt(DIFFICULTY_KEY,value);
		}else{
			Debug.LogError("Difficulty is not in range (1-3).");
		}
	}

	public static int GetDifficulty(){
		return PlayerPrefs.GetInt(DIFFICULTY_KEY);
	}
}

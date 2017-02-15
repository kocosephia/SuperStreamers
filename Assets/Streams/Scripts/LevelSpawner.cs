using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSpawner : MonoBehaviour {

	private static LevelSpawner instance;

	public Level baseLevel;
	public RectTransform levelParent;

	private int currentLevel = 0;
	private Level currentLevelObject;

	void Awake()
	{

		if (instance != null) {
			DestroyImmediate (this);
		} else {
			instance = this;
		}
	}

	public static Level GetCurrentLevel()
	{
		return instance.currentLevelObject;
	}

	public static void ResetLevel()
	{
		instance.currentLevel = 0;
		SpawnNewLevel ();
	}

	public static void SpawnNewLevel()
	{
		if (instance.currentLevelObject != null) {
			DestroyImmediate (instance.currentLevelObject.gameObject);
		}

		instance.currentLevel++;
		instance.currentLevelObject = Instantiate (instance.baseLevel, instance.levelParent) as Level;
		instance.currentLevelObject.GetComponent<RectTransform> ().localPosition = Vector3.zero;
		//instance.currentLevelObject.GetComponent<RectTransform> ().position = Vector3.zero;
		instance.currentLevelObject.levelName = "Level " + instance.currentLevel;
		instance.currentLevelObject.SetMaxHP (instance.currentLevelObject.baseHP + instance.currentLevelObject.baseHP * instance.currentLevelObject.hpIncreasePerLevel * instance.currentLevel);
		GameState.ChangeGold ( (int)(instance.currentLevelObject.baseGoldValue + instance.currentLevelObject.baseGoldValue * instance.currentLevel * instance.currentLevelObject.goldIncreasePerLevel));
		DamageDealer.SetTarget (instance.currentLevelObject);
	}
}

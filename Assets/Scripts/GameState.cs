using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

	public float baseDPS = 55.0f;

	private Dictionary<string, float> multipliers = new Dictionary<string, float> ();

	private static GameState instance;

	public Text dpsString;
	public Text currentStreamString;
	public Text goldString;

	private float timeRemaining;
	private float currentDPS;
	private int gold;
	private int streamNumber = 1;

	void Awake()
	{
		if (instance != null) {
			DestroyImmediate (this);
		} else {
			instance = this;
			instance.timeRemaining = 3000f;
			instance.currentDPS = instance.baseDPS;
		}
	}

	void Start()
	{
		if (LevelSpawner.GetCurrentLevel() == null) {
			LevelSpawner.SpawnNewLevel ();
		}
		Upgrades.SetupUpgrades ();
	}

	#region event callbacks

	public static void UpdateMultiplier(string multiplierName, float multiplierValue)
	{
		instance.multipliers [multiplierName] = multiplierValue;
		RecalculateMultipliers ();
	}

	public static void RecalculateMultipliers()
	{
		float total = 1;
		foreach (float value in instance.multipliers.Values) {
			total += value;
		}
		instance.currentDPS =  instance.baseDPS * total;
		DamageDealer.RecalculateDamage ();
	}

	public static void RemoveMultiplier(string multiplierName)
	{
		instance.multipliers.Remove (multiplierName);
		RecalculateMultipliers ();
	}

	#endregion

	public static int GetStreamNumber()
	{
		return instance.streamNumber;
	}

	public static float GetTimeRemaining()
	{
		return instance.timeRemaining;
	}

	public static float GetCurrentDPS()
	{
		return instance.currentDPS;
	}

	public static int GetCurrentGold()
	{
		return instance.gold;
	}

	public static bool ChangeGold(int deltaGold)
	{
		if ((instance.gold + deltaGold) < 0) {
			return false;
		} else {
			instance.gold += deltaGold;
			return true;
		}
	}

	public static void StartNewStream(string streamName)
	{
		instance.streamNumber++;
		instance.currentStreamString.text = streamName;
		instance.gold = 0;
		Upgrades.PurgeUpgradesForStream ();
		Upgrades.SetupUpgrades ();
	}
		
	
	// Update is called once per frame
	void FixedUpdate () {
		timeRemaining -= Time.fixedDeltaTime;
		dpsString.text = currentDPS.ToString ();
		goldString.text = gold.ToString ();
	}
}

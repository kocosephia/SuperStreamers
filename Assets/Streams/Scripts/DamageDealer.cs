using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

	private static DamageDealer instance;

	public bool willDealDamage = false;

	private Damageable currentTarget;
	private float damageToDealPerUpdate;


	void Awake()
	{
		if (instance != null) {
			DestroyImmediate (this);
		} else {
			instance = this;
		}
	}

	public static void SetTarget(Damageable newTarget)
	{
		instance.currentTarget = newTarget;
		RecalculateDamage ();
	}

	public static void RecalculateDamage()
	{
		instance.damageToDealPerUpdate = GameState.GetCurrentDPS() * Time.fixedDeltaTime;
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (willDealDamage && currentTarget!=null) {

			//If dealing damage completes level
			if (currentTarget.DealDamage (damageToDealPerUpdate)) {
				LevelSpawner.SpawnNewLevel ();
			}
		}
	}
}

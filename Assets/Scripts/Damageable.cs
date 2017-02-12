using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour {

	public float baseHP;

	protected float maxHP;
	protected float currentHP;


	public bool DealDamage(float damage)
	{
		currentHP -= damage;

		if (currentHP <= 0.0f) {
			currentHP = 0.0f;
			return true;
		}

		return false;
	}
		

}

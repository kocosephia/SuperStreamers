using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : Damageable{

	public string levelName;
	public Slider slider;
	public Text hpText;
	public float hpIncreasePerLevel = .25f;
	public int baseGoldValue = 10;
	public float goldIncreasePerLevel= .5f;

	void Start()
	{
	}

	public void SetMaxHP(float newMax)
	{
		float delta = newMax - maxHP;
		maxHP = newMax;
		currentHP += delta;
		slider.maxValue = maxHP;
	}

	void Update()
	{
		hpText.text= (int) currentHP + " / "+maxHP;
		slider.value = currentHP;
	}
}

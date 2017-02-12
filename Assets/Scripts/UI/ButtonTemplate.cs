using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonTemplate : MonoBehaviour {

	public delegate void ButtonClick(string buttonName, float value);
	public event ButtonClick ButtonClicked;

	public Image icon;
	public Text buttonName;
	public Text level;
	public Text costText;


	public float baseValue;
	public float baseCost;
	public float valueIncreasePerLevel;
	public float costIncreasePerLevel;
	public Permanency permanency;

	private Button thisButton;
	public int currentLevel;
	public int currentPrice;
	public float currentMultiplier;

	void OnEnable()
	{
		thisButton = GetComponent<Button> ();
		ButtonClicked += GameState.UpdateMultiplier;
	}

	void OnDisable()
	{
		ButtonClicked -= GameState.UpdateMultiplier;
	}


	public void ButtonPressed()
	{
		if (currentPrice <= GameState.GetCurrentGold ()) {
			GameState.ChangeGold (-currentPrice);
			LevelUp ();
			ButtonClicked (buttonName.text, currentMultiplier);
		}
	}

	private void LevelUp()
	{
		currentLevel++;
		currentPrice = (int)(baseCost * currentLevel * costIncreasePerLevel);
		currentMultiplier = (baseValue + ((currentLevel-1) * valueIncreasePerLevel));
	}
	void Update()
	{
		level.text = currentLevel.ToString ();
		costText.text = currentPrice.ToString ();

		if (currentPrice > GameState.GetCurrentGold ()) {
			thisButton.interactable = false;
		} else {
			thisButton.interactable = true;
		}
	}
}

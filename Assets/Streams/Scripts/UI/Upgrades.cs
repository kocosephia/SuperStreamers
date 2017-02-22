using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour {

	private static Upgrades instance;

	public Multiplier[] multipliers;
	public ButtonTemplate upgradeTemplate;

	private List<ButtonTemplate> activeButtons = new List<ButtonTemplate>();

	private RectTransform upgradePanelTrans;


	void Awake()
	{
		if (instance != null) {
			DestroyImmediate (this);
		} else {
			instance = this;
		}
		upgradePanelTrans = GetComponent<RectTransform> ();
	}

	
	public static void SetupUpgrades()
	{
		foreach (Multiplier mult in instance.multipliers) {
			ButtonTemplate thisButton = Instantiate (instance.upgradeTemplate, instance.upgradePanelTrans) as ButtonTemplate;
			instance.activeButtons.Add (thisButton);
			thisButton.icon.sprite = mult.icon;
			thisButton.buttonName.text = mult.name + GameState.GetStreamNumber();
			thisButton.currentLevel = 0;
			thisButton.currentMultiplier = mult.baseValue;
			thisButton.currentPrice = mult.baseCost;
			thisButton.baseCost = mult.baseCost;
			thisButton.baseValue = mult.baseValue;
			thisButton.valueIncreasePerLevel = mult.addedValuePerLevel;
			thisButton.costIncreasePerLevel = mult.costPerLevelMultiplier;
			thisButton.permanency = mult.permanency;
		}
	}

	public static void PurgeUpgradesForStream()
	{
		foreach (ButtonTemplate upgrade in instance.activeButtons) {
			if (upgrade.permanency == Permanency.STREAM) {
				GameState.RemoveMultiplier (upgrade.buttonName.text);
			}
			DestroyImmediate (upgrade.gameObject);
		}
		instance.activeButtons.Clear ();
	}
}

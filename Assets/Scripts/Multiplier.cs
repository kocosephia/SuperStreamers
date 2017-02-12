using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Multiplier", menuName = "SuperStreamers/DataObjects", order = 1)]
public class Multiplier : ScriptableObject {

	public string multiplierName;
	public Sprite icon;

	public Permanency permanency;

	public float baseValue;
	public int baseCost;

	public float addedValuePerLevel;
	public float costPerLevelMultiplier;

}

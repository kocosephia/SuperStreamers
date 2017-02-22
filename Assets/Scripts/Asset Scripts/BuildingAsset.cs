using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "SuperStreamers/BuildingAsset", order = 2)]
public class BuildingAsset : ScriptableObject {

	public string buildingName;
	public Sprite icon;
	public GameObject modelPrefab;
	public BuildingType buildingType;
	public int buildingLevel = 1;

	public BuildingRequirement[] requirements;

	public BuildingCost cost;

	public Resource generatedResource;
	public float resourcesPerSecond;

	public Resource[] consumedResources;

	public Resource[] producedResources;

	public float[] resourceConsumptionRates;

	public float[] productionRates;
}

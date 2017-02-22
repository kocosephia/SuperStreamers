using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "SuperStreamers/DataObjects", order = 2)]
public class BuildingAsset : ScriptableObject {

	public string buildingName;
	public Sprite icon;
	public GameObject modelPrefab;
	public BuildingType buildingType;
	public int buildingLevel = 1;

	public BuildingRequirement[] requirements;

	public float cost;

	public Resource generatedResource;
	public float resourcesPerSecond;

	public Resource consumedResource1;
	public Resource consumedResource2;
	public Resource producedResource;
	public float resource1ConsumptionRate;
	public float resource2ConsumptionRate;
	public float productionRate;
}

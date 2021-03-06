﻿

public enum Permanency { STREAM, ASCENTION, PERMANENT};

public enum BuildingType {HOUSE, PRODUCER1, PRODUCER2, CONVERTER1, CONVERTER2, TECH_BUILDING1, TECH_BUILDING2} 

public enum BuildingUpgrade {BOOST, LEVEL_UP}

public enum UniversalUpgrade {RATE_DISCOUNT, RATE_INCREASE}

public enum Resource {DIRT, MUD, STONE, TIN, IRON, GOLD, URANIUM}

public struct BuildingRequirement
{
	public BuildingType buildingType;
	public int buildingLevel;
}

public struct BuildingCost {
	public Resource[] costs;
}
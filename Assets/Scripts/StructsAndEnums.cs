

public enum Permanency { STREAM, ASCENTION, PERMANENT};

public enum BuildingType {HOUSE, PRODUCER1, PRODUCER2, CONVERTER1, CONVERTER2, TECH_BUILDING1, TECH_BUILDING2} 

public enum Resource {DIRT, MUD, STONE, TIN, IRON, GOLD, URANIUM}

public struct BuildingRequirement
{
	public BuildingType buildingType;
	public int buildingLevel;
}
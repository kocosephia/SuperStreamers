using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CubeGrid : MonoBehaviour {

	public Vector3 origin = Vector3.zero;

	[Range(1, 10)]
	public int maxX;
	[Range(1, 10)]
	public int maxZ;

	public void PositionObjects()
	{
		int currentX = 0;
		int currentZ = 0;
		foreach (Transform child in transform) {

			if (currentX >= maxX) {
				currentX = 0;
				currentZ++;
			}
			if (currentZ > maxZ) {
				return;
			}
			child.position = new Vector3 (currentX, 0f, currentZ);
			currentX++;
		}
	}
}

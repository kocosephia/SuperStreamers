using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CubeGrid : MonoBehaviour {

	public Vector3 origin = Vector3.zero;
	public GameObject cubePrefab;

	[SerializeField]
	private List<GameObject> goList = new List<GameObject>();

	[Range(1, 10)]
	public int maxX;
	[Range(1, 10)]
	public int maxZ;

	public void CreateGrid()
	{
		foreach (GameObject go in goList) {
			DestroyImmediate (go);
		}
		goList.Clear ();
		for (int i = 0; i < maxX * maxZ; i++) {
			goList.Add (Instantiate (cubePrefab, transform));
		}

		int currentX = 0;
		int currentZ = 0;
		foreach (GameObject child in goList) {

			if (currentX >= maxX) {
				currentX = 0;
				currentZ++;
			}
			if (currentZ > maxZ) {
				return;
			}
			child.transform.position = new Vector3 (currentX, 0f, currentZ);
			currentX++;
		}
	}
}

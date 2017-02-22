using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CubeGrid))]
public class CubeGridEditor : Editor {

	public override void OnInspectorGUI ()
	{
		CubeGrid cubeGrid = (CubeGrid)target;

		DrawDefaultInspector ();

		if (GUILayout.Button ("Reposition")) {
			cubeGrid.PositionObjects ();
		}
	}
}

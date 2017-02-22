using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuildingAsset))]
public class BuildingAssetEditor : Editor {

	//SerializedProperty lookAtPoint;

	void OnEnable()
	{
		//lookAtPoint = serializedObject.FindProperty("lookAtPoint");
	}

		public override void OnInspectorGUI()
	{
		base.OnInspectorGUI ();
	}

}

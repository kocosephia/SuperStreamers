﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuildingAsset))]
public class BuildingAssetEditor : Editor {

	SerializedProperty lookAtPoint;

	void OnEnable()
	{
		lookAtPoint = serializedObject.FindProperty("lookAtPoint");
	}

		public override void OnInspectorGUI()
	{
		serializedObject.Update ();
		EditorGUILayout.PropertyField (lookAtPoint);
		serializedObject.ApplyModifiedProperties ();
		if (lookAtPoint.vector3Value.y > (target as LookAtPoint).transform.position.y) {
			EditorGUILayout.LabelField ("(Above this object)");
		}
		if (lookAtPoint.vector3Value.y < (target as LookAtPoint).transform.position.y) {
			EditorGUILayout.LabelField ("(Below this object)");
		}
	}

}

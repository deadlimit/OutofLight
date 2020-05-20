using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(RoomColors))]
public class RoomColorEditor : Editor {
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();

		var room = (RoomColors) target;
		
		if (GUILayout.Button("Populate list")) {
			room.PopulateList();
		}
	}
}

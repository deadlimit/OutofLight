using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class RoomColors : ScriptableObject {

	public Dictionary<string, Color> roomColors = new Dictionary<string, Color>();


	public string[] scenes;
	public Color[] colors;

	private void OnEnable() {
		PopulateList();
	}

	public void PopulateList() {
		for (int i = 0; i < scenes.Length; i++) {
			roomColors.Add(scenes[i], colors[i]);
		}
		
	}

}

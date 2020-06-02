using System;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	public Dictionary<string, Action> reloadSceneObjects = new Dictionary<string, Action>();

	public void Awake() {
		reloadSceneObjects.Add("hej", () => reloadSceneObjects.Clear());
	}
	
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class NewBehaviourScript : MonoBehaviour {

	public Dictionary<string, Action> reloadSceneObjects = new Dictionary<string, Action>();

	public void Awake() {
		reloadSceneObjects.Add("hej", () => reloadSceneObjects.Clear());
	}
	
}

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RequirementManager : MonoBehaviour {

	public static RequirementManager Instance;
	
	public List<string> requirementName = new List<string>();
	
	public Dictionary<string, bool> requirementList = new Dictionary<string, bool>();
	
	private void Awake() {
		if (Instance != null && Instance != this) {
			Destroy(gameObject);
		}
		Instance = this;
		DontDestroyOnLoad(this);
		
		PopulateDictionary();
	}

	public void FulfillRequirement(string name, bool value) {
		requirementList[name] = value;

		foreach (var b in requirementList) {
			print(b);
		}
	}

	public bool CheckSpecificRequirements(string name) {
		return requirementList[name];
	}

	private void PopulateDictionary() {
		foreach (var t in requirementName) {
			requirementList.Add(t, false);
		}
	}
}

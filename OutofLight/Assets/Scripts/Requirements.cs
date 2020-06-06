using System.Collections.Generic;
using UnityEngine;

public class Requirements : MonoBehaviour {

	public static Requirements Instance;

	public List<string> nameOfRequirement = new List<string>();
	public List<bool> valueOfRequirement = new List<bool>();
	
	public Dictionary<string, bool> requirements = new Dictionary<string, bool>();

	private void Awake() {
		if (Instance != null && Instance != this)
			Destroy(gameObject);

		Instance = this;
		DontDestroyOnLoad(gameObject);
		
		Debug.Log(requirements);
	}

	public void FulfillRequirement(string name, bool value) {
		requirements[name] = value;
	}
	
	public void ResetValues(){
		foreach (var b in requirements.Keys) {
			requirements[b] = false;
		}
	}
	
	private void PopulateDictionary() {
		for (int i = 0; i < nameOfRequirement.Count; i++) {
			requirements.Add(nameOfRequirement[i], valueOfRequirement[i]);
		}
	}
	
	
	

}

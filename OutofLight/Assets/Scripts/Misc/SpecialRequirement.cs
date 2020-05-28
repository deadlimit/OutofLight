using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
public class SpecialRequirement : MonoBehaviour, IInteractable {

	
	public string prompt;
	public Button button;
	private BoxCollider thisCollider;
	public List<BoolVariable> requirements = new List<BoolVariable>();

	private bool requirementsMet;
	private BoxCollider[] collidersInParent;
	
	public void Awake() {
		
		thisCollider = GetComponent<BoxCollider>();
		collidersInParent = GetComponentsInParent<BoxCollider>();
		DelegateCheckRequirements();
		EnableColliders(false);

		thisCollider.enabled = true;
		
	}

	public void Use() {

	}

	public string GetPrompt() {
		return prompt;
	}

	public Button CustomSprite() {
		return button;
	}

	private void EnableColliders(bool on) {
		foreach (var coll in collidersInParent)
			coll.enabled = on;
	}

	public void DelegateCheckRequirements() {
		requirementsMet = CheckRequirements();
		if (requirementsMet) {
			EnableColliders(true);
			Destroy(gameObject);
		}

	}
	
	private bool CheckRequirements() {
		return requirements.All(req => req.IsTrue());
	}
}

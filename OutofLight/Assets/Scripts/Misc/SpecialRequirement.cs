using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class SpecialRequirement : MonoBehaviour, IInteractable {

	
	public string prompt;
	public Button button;
	private BoxCollider thisCollider;
	public List<BoolVariable> requirements = new List<BoolVariable>();
	private bool requirementsMet;
	public BoxCollider[] collidersInParent;
	
	public void Awake() {
		thisCollider = GetComponent<BoxCollider>();
		DelegateCheckRequirements();
		if (requirementsMet) return;
		EnableColliders(false);
		thisCollider.enabled = true;
	}

	public void Use() {
		var text = GetComponentInChildren<RequirementText>();
		text.MoveAndShowText();
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

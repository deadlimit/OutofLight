using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarredUpDoor : MonoBehaviour, IInteractable {

	public GameEvent SpecialEvent;
	public Button interactImage;
	public string fulfillRequirement;
	public void Use() {
		if(fulfillRequirement.Length > 0)
			RequirementManager.Instance.FulfillRequirement(fulfillRequirement, true);
		SpecialEvent.Raise();
	}

    public string GetPrompt() {
	    return "Try to open";
    }

    public Button CustomSprite() {
	    return interactImage;
    }
    
}


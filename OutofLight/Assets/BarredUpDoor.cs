using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarredUpDoor : MonoBehaviour, IInteractable {

	public GameEvent SpecialEvent;
	
	public void Use() {
	    Debug.Log("Barred door");
	    SpecialEvent.Raise();
	}

    public string GetPrompt() {
	    return "Try to open";
    }

}


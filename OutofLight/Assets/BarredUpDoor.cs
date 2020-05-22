using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarredUpDoor : MonoBehaviour, IInteractable {

    public void Use() {
	    Debug.Log("Barred door");
	}

    public string GetPrompt() {
	    return "Try to open";
    }

}

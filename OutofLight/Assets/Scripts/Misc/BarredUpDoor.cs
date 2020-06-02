﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarredUpDoor : MonoBehaviour, IInteractable {

	public GameEvent SpecialEvent;
	public Button interactImage;
	public BoolVariable CanEnterLibrary;
	public void Use() {
	 	CanEnterLibrary.ChangeValue(true);
	    SpecialEvent.Raise();
	}

    public string GetPrompt() {
	    return "Try to open";
    }

    public Button CustomSprite() {
	    return interactImage;
    }
    
}


using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class JournalBehavior : MonoBehaviour, IInteractable {

    public GameEvent PageFound;
    public JournalPage page;
    public Journal journal;
    public Button interactImage;
    
    
    
    public void Use() {
        journal.Add(page);
        PageFound.Raise();
        Destroy(gameObject);
    }

    public string GetPrompt() {
        return "Pick up journal page";
    }

    public Button CustomSprite() {
        return interactImage;
    }
}

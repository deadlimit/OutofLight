using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class JournalBehavior : MonoBehaviour, IInteractable {

    public GameEvent PageFound;
    public JournalPage page;
    public Journal journal;
    public Sprite interactImage;
    
    
    
    public void Use() {
        journal.Add(page);
        PageFound.Raise();
        Destroy(gameObject);
    }

    public string GetPrompt() {
        return "Pick up journal page";
    }

    public Sprite CustomSprite() {
        return interactImage;
    }
}

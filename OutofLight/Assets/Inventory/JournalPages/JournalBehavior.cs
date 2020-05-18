using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalBehavior : MonoBehaviour, IInteractable {

    public GameEvent PageFound;
    public JournalPage page;
    public Journal journal;
    public void Use() {
        journal.Add(page);
        PageFound.Raise();
        Destroy(gameObject);
    }
}

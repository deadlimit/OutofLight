using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalBehavior : MonoBehaviour, IInteractable {

    public GameObject journalUIPrefab;
    public JournalPage page;
    public Journal journal;
    public void Use() {
        
        journal.Add(page);
        Destroy(gameObject);
    }
}

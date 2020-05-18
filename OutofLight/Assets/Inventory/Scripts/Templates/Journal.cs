using System;
using UnityEngine;
[CreateAssetMenu(menuName = "Inventory/Journal")]
public class Journal : ScriptableObject {

    public int pages;

    public JournalPage[] journal;

    public void Add(JournalPage page) {
        journal[page.journalPageEntry] = page;
    }
    
    public void OnEnable() {
        journal = new JournalPage[pages];
    }
}

using System;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(menuName = "Inventory/Journal")]
public class Journal : ScriptableObject {

    public int pages;

    public JournalPage[] journal;
    public JournalPage latest;
    
    public void Add(JournalPage page) {
        journal[page.journalPageEntry] = page;
        latest = page;
    }
    
    public void OnEnable() {
        journal = new JournalPage[pages];
        latest = null;
    }

    public JournalPage GetPage(int index) {
        return journal[index];
    }

    public void Remove(JournalPage page) {
        if (journal.Length < 1) return;
        for (var i = 0; i < journal.Length; i++) {
            if(journal[i] == null) continue;
            if (journal[i].day.Equals(page.day)) {
                journal[i] = null;
                Debug.Log("Removed: " + page.day);
                return;
            }
        }
    }

    public bool Contains(JournalPage page) {
        return journal.Contains(page);
    }
}

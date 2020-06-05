using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(menuName = "Inventory/Journal")]
public class Journal : ScriptableObject {

    public int pages;
    
    public List<JournalPage> journal;
    public JournalPage latest;
    
    public void Add(JournalPage page) {
        journal.Add(page);
        journal.Sort();
        latest = page;
    }
    
    public void OnEnable() {
        journal = new List<JournalPage>(12);
        journal.Sort();
        latest = null;
    }

    public JournalPage GetPage(int index) {
        return journal[index];
    }

    public void Remove(JournalPage page) {
        if (journal.Count < 1) return;
        for (var i = 0; i < journal.Count; i++) {
            if (journal[i].day.Equals(page.day)) {
                journal.Remove(journal[i]);
                return;
            }
        }
    }

    public bool Contains(JournalPage page) {
        return journal.Contains(page);
    }
}

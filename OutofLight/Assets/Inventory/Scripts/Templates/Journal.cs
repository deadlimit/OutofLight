﻿using System;
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

    public bool Contains(JournalPage page) {
        return journal.Contains(page);
    }
}

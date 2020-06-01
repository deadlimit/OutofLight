using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
[CreateAssetMenu(menuName = "Inventory/JournalPage")]
public class JournalPage : ScriptableObject, IComparable {
    
    public int journalPageEntry;
    public string day;
    public string header = "Journal of Baron James Tristan";
    [TextAreaAttribute(10, 15)]
    public string entry;

    public bool dontRespawn;
    
    private void OnEnable() {
        dontRespawn = false;
        day = "Day " + (journalPageEntry + 1);
    }

    public int CompareTo(object obj) {
        return (JournalPage) obj == this ? 0 : -1;
    }
}

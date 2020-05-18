using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
[CreateAssetMenu(menuName = "Inventory/JournalPage")]
public class JournalPage : ScriptableObject {
    
    public int journalPageEntry;
    public string day;
    public string header = "Journal of Baron James Tristan";
    [TextAreaAttribute(10, 15)]
    public string entry;

    private void OnEnable() {
        day = "Day " + (journalPageEntry + 1);
    }
}

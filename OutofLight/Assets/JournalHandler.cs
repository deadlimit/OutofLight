using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class JournalHandler : MonoBehaviour {

    public Journal journal;
    public GameObject JournalPageUI;
    
    public Image background;
    public Text day;
    public Text header;
    public Text entry;

    private GameObject[] uiComponents;

    public void Awake() {
        uiComponents = {background, day, header, entry};
        ChangeUIComponentsVisible(false);
    }

    public void DisplayJournalPage() {
        ChangeUIComponentsVisible(true);
        JournalPage page = journal.latest;
        if (page == null) return; 
        day.text = page.day;
        header.text = page.header;
        entry.text = page.entry;
    }

    public void Close() {
        day.text = null;
        header.text = null;
        entry.text = null;
        ChangeUIComponentsVisible(false);
    }

    private void ChangeUIComponentsVisible(bool visible) {
        foreach(var comp in uiComponents)
            comp.SetActive(visible);
    }
}

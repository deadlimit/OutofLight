using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class JournalHandler : MonoBehaviour {

    public Journal journal;
    public GameObject JournalPageUI;
    
    public Image background;
    public Text day;
    public Text header;
    public Text entry;
    public Button close;
    

    public void Awake()
    {
        ChangeUIComponentsVisible(false);
    }

    public void DisplayJournalPage() {
        ChangeUIComponentsVisible(true);
        var page = journal.latest;
        if (page == null) return; 
        day.text = page.day;
        header.text = page.header;
        entry.text = page.entry;
    }

    public void Close() {
        Debug.Log("wefwef");
        day.text = null;
        header.text = null;
        entry.text = null;
        ChangeUIComponentsVisible(false);
    }

    private void ChangeUIComponentsVisible(bool visible)
    {
        background.enabled = visible;
        day.enabled = visible;
        header.enabled = visible;
        entry.enabled = visible;
        close.gameObject.SetActive(visible);
        
    }
}

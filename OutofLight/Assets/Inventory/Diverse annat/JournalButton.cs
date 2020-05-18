using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class JournalButton : MonoBehaviour {

    public GameObject journalUI;

    private GameObject internalReference;
    private Button menuButton;
    private bool journalShowing;

    private void Awake() {
        menuButton = GetComponent<Button>();
        journalShowing = false;
        ChangeOnClick();
    }
    
    private void OpenJournal() {
        var journal = Instantiate(journalUI);
        journal.transform.SetParent(GameObject.FindWithTag("UI").transform, false);
        internalReference = journal;
        journalShowing = true;
        ChangeOnClick();
    }

    private void CloseJournal() {
        Destroy(internalReference);
        journalShowing = false;
        ChangeOnClick();
    }

    private void ChangeOnClick() {
        menuButton.onClick.RemoveAllListeners();
        if(journalShowing)
            menuButton.onClick.AddListener(CloseJournal);
        else {
            menuButton.onClick.AddListener(OpenJournal);
        }
    }

}

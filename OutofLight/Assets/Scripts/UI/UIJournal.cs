﻿
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class UIJournal : MonoBehaviour {

    public Sprite emptySlot;
    public Sprite occupiedSlot;
    public GameObject journalHandler;
    public Journal journal;
    public Button[] slots;
    public Text[] slotTexts;

    private AudioSource audio;
    private Canvas canvas;
    private void Awake(){
        Fill();
        audio = GetComponent<AudioSource>();
        canvas = GameObject.Find("UI 3.0").GetComponentInParent<Canvas>();
    }

    private void Fill() {
        List<JournalPage> pages = journal.journal;
        foreach (var page in pages.Where(page => page != null)) {
            print(page.day);
            slots[page.journalPageEntry].image.sprite = occupiedSlot;
            slotTexts[page.journalPageEntry].text = page.day;
            slots[page.journalPageEntry].onClick.AddListener(delegate { Display(page);});
        }
    }
    
    private void Display(JournalPage page) {
        var g = Instantiate(journalHandler, canvas.transform.position, quaternion.identity, canvas.transform);
        g.GetComponent<JournalHandler>().PopulateJournalWindow(page);
        audio.Play();
    }
    
}

using System.Net.Cache;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class UIJournal : MonoBehaviour {

    public Sprite emptySlot;
    public Sprite occupiedSlot;
    public GameObject journalHandler;
    public Journal journal;
    public Button[] slots;
    public Text[] slotTexts;
    
    private void Awake(){
        Fill();
    }

    private void Fill() {
        foreach (var page in journal.journal) {
            if (page == null) continue;
            slots[page.journalPageEntry].image.sprite = occupiedSlot;
            slotTexts[page.journalPageEntry].text = page.day;
            slots[page.journalPageEntry].onClick.AddListener(delegate { Display(page);});
        }
    }
    
    private void Display(JournalPage page) {
        var g = Instantiate(journalHandler, transform.parent);
        g.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        g.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        g.GetComponent<JournalHandler>().page = page;
    }
    
}

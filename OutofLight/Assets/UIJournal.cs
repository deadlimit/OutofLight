using UnityEngine;
using UnityEngine.UI;

public class UIJournal : MonoBehaviour {

    public Sprite emptySlot;
    public Sprite occupiedSlot;
    
    public Journal journal;
    public Button[] slots;
    public Text[] slotTexts;

    private void Awake(){
        slots = GetComponentsInChildren<Button>();
        slotTexts = GetComponentsInChildren<Text>();
    }

    private void OnEnable() {
        for (int i = 0; i < slots.Length; i++) {
            slots[i].image.sprite = journal.journal[i] == null ? emptySlot : occupiedSlot;
        }
    }

}

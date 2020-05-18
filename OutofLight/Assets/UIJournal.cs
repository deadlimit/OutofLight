using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIJournal : MonoBehaviour
{

    public Journal journal;
    public Button[] slots;
    public Text[] slotTexts;
    
    private void Awake()
    {
        slots = GetComponentsInChildren<Button>();
        slotTexts = GetComponentsInChildren<Text>();
    }

}

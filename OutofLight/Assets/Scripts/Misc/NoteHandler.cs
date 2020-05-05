using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteHandler : MonoBehaviour
{
    public Image paper;

    [SerializeField]
    private GameEvent notePickup;
    void Start()
    {
        paper.gameObject.SetActive(false);
    }

    public void PaperPickedUp()
    {
        paper.gameObject.SetActive(true);
    }

}

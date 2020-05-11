using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteHandler : MonoBehaviour
{
    public Image paper;
    public Text noteText;


    void Start()
    {
        paper.enabled = false;
        noteText.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        paper.enabled = true;
        noteText.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        paper.enabled = false;
        noteText.enabled = false;
    }



}

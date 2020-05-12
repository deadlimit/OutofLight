using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteHandler : MonoBehaviour
{
    public Image paper;
    public Text noteText;
    public StringList content;

    private GameObject button;
    private bool isDoneReading;

    void Start()
    {
        paper.enabled = false;
        noteText.enabled = false;
        noteText.text = content.getText();
        button = GameObject.Find("ReadButton");
        button.gameObject.SetActive(false);
        isDoneReading = false;       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            paper.enabled = true;
            noteText.enabled = true;
            button.SetActive(true);           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            paper.enabled = false;
            noteText.enabled = false;
            button.SetActive(false);
        }
    }

    public void doneReading()
    {
        isDoneReading = true;
        paper.enabled = false;
        noteText.enabled = false;
        button.SetActive(false);
    } 

}



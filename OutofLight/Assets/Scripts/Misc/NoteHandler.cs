using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteHandler : MonoBehaviour
{
    public Image paper;
    public Text noteText;
    public StringList content;

    private Transform _transform;
    private GameObject button;
    private bool isDoneReading;

    [SerializeField]
    private bool rotate;

    void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    void Start()
    {
        paper.enabled = false;
        paper.GetComponent<Animation>();
        noteText.enabled = false;
        noteText.text = content.getText();
        button = GameObject.Find("ReadButton");
        button.gameObject.SetActive(false);
        isDoneReading = false;       
    }

    private void Update()
    {
        if (rotate)
        {
            Rotate();
        }
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
    private void Rotate()
    {
        var angle = new Vector3(Random.Range(1, 360), Random.Range(1, 360), Random.Range(1, 360));

        _transform.Rotate(angle * Time.deltaTime / 10, Space.World);
    }

}



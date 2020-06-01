using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour, IInteractable {

    public GameEvent LeverPulled;
    public BoolVariable LeverNoPulled;
    public string prompt;
    public Button interactImage;
    private bool isPlayerInRange;

    public GameObject leverObject;

    private AudioSource audio;

    private void Awake() {
        audio = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        if (!isPlayerInRange) return;
        if (!Input.GetKeyDown(KeyCode.E)) return;
        print("Level pulled!");
        LeverPulled.Raise();
        LeverNoPulled.IsTrue();
        GetComponent<Lever>().enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        isPlayerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        isPlayerInRange = false;
    }

    public void Use() {
        var leverObj = leverObject.GetComponent<ILever>();
        leverObj?.Method();
        print("Level pulled!");
        LeverPulled.Raise();
        audio.Play();
        LeverNoPulled.ChangeValue(true);
        GetComponent<Lever>().enabled = false;
    }

    public string GetPrompt() {
        return prompt;
    }

    public Button CustomSprite() {
        return interactImage;
    }
    
}

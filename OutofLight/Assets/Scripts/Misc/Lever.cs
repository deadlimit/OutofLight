using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable {

    public GameEvent LeverPulled;
    public BoolVariable LeverNoPulled;
    public string prompt;

    private bool isPlayerInRange; 
    

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
        print("Level pulled!");
        LeverPulled.Raise();
        LeverNoPulled.ChangeValue(true);
        GetComponent<Lever>().enabled = false;
    }

    public string GetPrompt() {
        return prompt;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable {

    public GameEvent LeverPulled;
    public BoolVariable LeverNoPulled;

    private bool isPlayerInRange; 

    void Update()
    {
        if (!isPlayerInRange) return;
        if (!Input.GetKeyDown(KeyCode.E)) return;
        print("Level pulled!");
        LeverPulled.Raise();
        LeverNoPulled.IsTrue();
        GetComponent<Lever>().enabled = false;
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            isPlayerInRange = false;
        }
    }

    public void Use() {
        print("Level pulled!");
        LeverPulled.Raise();
        LeverNoPulled.ChangeValue(true);
        GetComponent<Lever>().enabled = false;
    }
}

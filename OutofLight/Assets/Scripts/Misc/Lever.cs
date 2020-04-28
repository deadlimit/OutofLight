using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    public GameEvent LeverPulled;

    private bool isPlayerInRange; 

    void Update() {
        if (isPlayerInRange) {
            if (Input.GetKeyDown(KeyCode.E)) {
                print("Level pulled!");
                LeverPulled.Raise();
                GetComponent<Lever>().enabled = false;
            }
        }
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

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNewScene : MonoBehaviour, IInteractable {

    public int newSceneIndex;

    public BoolVariable doorActive;

    public bool canUseDoor;

    

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")){
            canUseDoor = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            canUseDoor = false;
        }
    }

    public void LoadNewScene() {
        SceneManager.LoadScene(newSceneIndex);
    }

    public void Use() {
        //if(canUseDoor)
            LoadNewScene();
    }
}

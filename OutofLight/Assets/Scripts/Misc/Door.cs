using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable {

    public int newSceneIndex;

    [SerializeField] private bool closeToDoor;
  
    public void IsCloseToDoor(bool value) {
        closeToDoor = value;
    }

    public void Use() {
        if(closeToDoor)
            SceneManager.LoadScene(newSceneIndex);  
    }


}

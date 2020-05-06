using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable {

    public int newSceneIndex;

    public GameEvent NewSceneLoad;

    public SpawnPosition spawn;

    public Vector3 otherSide;

    [SerializeField] private bool closeToDoor;
  
    public void IsCloseToDoor(bool value) {
        closeToDoor = value;
    }

    public void Use() {
        if (closeToDoor) {
            NewSceneLoad.Raise();
            spawn.spawnPosition = otherSide;
            SceneManager.LoadScene(newSceneIndex);
        }
            
                  
    }


}

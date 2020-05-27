using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : MonoBehaviour, IInteractable {

    public TransitInfo transitInfo;
    
    public GameEvent NewSceneLoad;
    
    public CinemachineVirtualCamera doorCamera;
    public SpawnPosition spawn;
    public Sprite interactImage;

    public string prompt;

    private void Awake() {
        doorCamera.gameObject.SetActive(false);
    }
    
    public void Use() {
        StartCoroutine(NewSceneSequence());
    }

    private IEnumerator NewSceneSequence() {
        NewSceneLoad.Raise();
        doorCamera.gameObject.SetActive(true);
        spawn.spawnPosition = transitInfo.otherSide;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(transitInfo.sceneNumber);
    }

    public string GetPrompt() {
        return prompt;
    }
    

    public Sprite CustomSprite() {
        return interactImage;
    }
}
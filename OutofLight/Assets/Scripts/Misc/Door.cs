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
    public GameEvent PlayerOpenAnimationTrigger;
    
    public CinemachineVirtualCamera doorCamera;
    public SpawnPosition spawn;
    public Button interactImage;
    
    public string prompt;

    private void Awake() {
        doorCamera.gameObject.SetActive(false);
    }
    
    public void Use() {
        StartCoroutine(NewSceneSequence());
    }

    private IEnumerator NewSceneSequence() {
        NewSceneLoad.Raise();
        PlayerOpenAnimationTrigger.Raise();
        doorCamera.gameObject.SetActive(true);
        spawn.spawnPosition = transitInfo.otherSide;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(transitInfo.sceneNumber);
    }

    public string GetPrompt() {
        return prompt;
    }
    

    public Button CustomSprite() {
        return interactImage;
    }

    public string AnimationTrigger() {
        throw new System.NotImplementedException();
    }
}
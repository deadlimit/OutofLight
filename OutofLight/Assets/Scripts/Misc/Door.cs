using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable {

    public TransitInfo transitInfo;
    
    public GameEvent NewSceneLoad;

    public SpawnPosition spawn;
    
    public void Use()
    {
        NewSceneLoad.Raise();
        spawn.spawnPosition = transitInfo.otherSide;
        SceneManager.LoadScene(transitInfo.sceneNumber);
    }


}
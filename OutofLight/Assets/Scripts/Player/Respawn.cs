using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    [SerializeField][Header ("Check för den aktiva scenen:")]
    private int currentScene;
    private GameObject respawnMenu;

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void respawn()
    {
        SceneManager.LoadScene(currentScene);
        respawnMenu = GameObject.Find("RespawnMechanic_2.0");
        Destroy(respawnMenu);
    }
}

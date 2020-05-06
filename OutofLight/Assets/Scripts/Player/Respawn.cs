using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public Text gameOverText;
    [SerializeField]
    private int currentScene;

    void Update()
    {
        if (gameOverText.enabled == true)
        {
            SceneManager.LoadScene(currentScene);
        }
    }
}

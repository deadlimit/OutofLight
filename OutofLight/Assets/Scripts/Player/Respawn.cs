using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public Image fade;
    public float fadeSpeed;
    public Color start;
    [SerializeField][Header ("Check för den aktiva scenen:")]
    private int currentScene;
    private GameObject respawnMenu;

    private void Awake()
    {
        fade.color = start;
    }

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        Fader();
    }

    public void respawn()
    {
        SceneManager.LoadScene(currentScene);
        respawnMenu = GameObject.Find("RespawnMechanic_2.0");
        Destroy(respawnMenu);
    }

    private void Fader()
    {
        fade.CrossFadeAlpha(254f, fadeSpeed, false);
    }
}

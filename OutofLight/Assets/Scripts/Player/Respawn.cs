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
    public Journal journal;
    [SerializeField][Header ("Check för den aktiva scenen:")]
    private int currentScene;

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
    }

    private void Fader()
    {
        fade.CrossFadeAlpha(254f, fadeSpeed, false);
    }
    public void ReturnToMenu()
    {
        for (int i = 0; i < journal.journal.Length; i++)
        {
            var journalEntry = journal.GetPage(i);
            Destroy(journalEntry);
        }
        SceneManager.LoadScene(0);
    }
}

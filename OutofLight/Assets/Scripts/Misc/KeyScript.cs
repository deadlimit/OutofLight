using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyScript : MonoBehaviour, IInteractable
{
    public AudioSource audio;
    public BoolVariable hasKey;
    public Button interactImage;
    public string prompt;
    public int currentScene;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void Use() 
    {
        if (SceneManager.GetActiveScene().buildIndex == currentScene)
        {
            audio.Play();
            hasKey.ChangeValue(true);
            Destroy(gameObject);
        }
    }

    public string GetPrompt()
    {
        return prompt;
    }

    public Button CustomSprite()
    {
        return interactImage;
    }
}

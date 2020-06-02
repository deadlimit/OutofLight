using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour, IInteractable
{
    public AudioSource audio;
    public BoolVariable hasKey;
    public Button interactImage;
    public string prompt;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Use() 
    {
        audio.Play();
        hasKey.ChangeValue(true);
        Destroy(gameObject);
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

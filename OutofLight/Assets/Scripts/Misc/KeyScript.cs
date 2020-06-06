using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyScript : MonoBehaviour, IInteractable
{
    public AudioSource audio;
    public string hasKey;
    public Button interactImage;
    public string prompt;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Use() 
    {
        audio.Play();
        RequirementManager.Instance.FulfillRequirement(hasKey, true);
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

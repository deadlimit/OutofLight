using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour {
    
    
    public InteractParameter interact;
    public GameEvent InteractTrigger;
    public Text interactTextFront, interactTextBack;
    public Sprite defaultSprite;
    public Button defaultButton;
    public Material shader;
    private Button thisButton;
    private Image defaultImage;

    private AudioSource audio;
   
    private void Awake() {
        audio = GetComponent<AudioSource>();
        defaultImage = GetComponent<Image>();
        defaultImage.sprite = null;
        thisButton = GetComponent<Button>();
    }

    public void SetNewInteract() {
        StartCoroutine(ChangeShader(-2));
        try {
            var interactButton = interact.thisObject.CustomSprite();
            SetNewButtonSprites(interactButton != null ? interactButton : defaultButton);
            interactTextFront.text = interact.thisObject.GetPrompt();
            interactTextBack.text = interact.thisObject.GetPrompt();
            thisButton.onClick.AddListener(Interact);
        }
        catch (NullReferenceException e) {
            print(e);
        }
    }

    private void Interact() {
        interact.thisObject.Use();
        audio.Play();
        StartCoroutine(ChangeShader(3));
        InteractTrigger.Raise();
    }
    
    public void Reset() {
        StartCoroutine(ChangeShader(2));
        thisButton.onClick.RemoveAllListeners();
    }
    
    private void SetNewButtonSprites(Selectable newButton) {
        shader = newButton.image.material;
        defaultImage.material = newButton.image.material;
        thisButton.spriteState = newButton.spriteState;
    }
    
    private IEnumerator ChangeShader(int value) {
        float start = 0;
        float end = 1;
        StartCoroutine(TextFade(-value, end * .7f));
        while (start < end) {
            float changeValue = Mathf.Lerp(shader.GetFloat("ShaderController"), value, Time.deltaTime * 1.5f);
            shader.SetFloat("ShaderController", changeValue);
            start += Time.deltaTime;
            yield return null;
        }
    }


    private IEnumerator TextFade(float value, float time) {
        var alpha = interactTextFront.color.a;
        for (var t = 0.0f; t < 1.0f; t += Time.deltaTime / time) {
            var newColor = new Color(interactTextFront.color.r, interactTextFront.color.g, interactTextFront.color.b,
                Mathf.Lerp(alpha, value, t));
            interactTextFront.color = newColor;
            interactTextBack.color = newColor;
            yield return null;
        }
    }
    
}

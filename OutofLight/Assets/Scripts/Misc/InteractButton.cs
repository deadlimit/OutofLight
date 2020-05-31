using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour {
    
    
    public InteractParameter interact;
    public GameEvent InteractTrigger;
    public Text interactTextFront, interactTextBack;
    public Sprite defaultSprite;
    public Button defaultButton;
    
    private Button thisButton;
    private Image defaultImage;
    public Material shader;
    private void Awake() {
        defaultImage = GetComponent<Image>();
        defaultImage.sprite = defaultSprite;
        thisButton = GetComponent<Button>();
    }

    public void SetNewInteract() {
        Debug.Log("New interact");
        StartCoroutine(ChangeShader(-3));
        try {
            var interactImage = interact.thisObject.CustomSprite();
            SetNewButtonSprites(interactImage != null ? interactImage : defaultButton);
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
        StartCoroutine(ChangeShader(3));
        InteractTrigger.Raise();
    }
    
    public void Reset() {
        StartCoroutine(ChangeShader(3));
        thisButton.onClick.RemoveAllListeners();
        defaultImage.sprite = defaultSprite;
        interactTextFront.text = null;
        interactTextBack.text = null;
    }
    
    private void SetNewButtonSprites(Selectable newButton) {
        defaultImage.sprite = newButton.image.sprite;
        thisButton.spriteState = newButton.spriteState;
    }


    private IEnumerator ChangeShader(int value) {
        float start = 0;
        float end = 1;
        while (start < end) {
            float changeValue = Mathf.Lerp(shader.GetFloat("Vector1_380668A9"), value, Time.deltaTime * 1.5f);
            shader.SetFloat("Vector1_380668A9", changeValue);
            start += Time.deltaTime;
            yield return null;
        }
    }

}

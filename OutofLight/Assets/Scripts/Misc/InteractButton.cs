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
    public Material shader;
    private Button thisButton;
    private Image defaultImage;
   
    private void Awake() {
        defaultImage = GetComponent<Image>();
        defaultImage.sprite = null;
        thisButton = GetComponent<Button>();
    }

    public void SetNewInteract() {
        StartCoroutine(ChangeShader(-3));
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
        StartCoroutine(ChangeShader(3));
        InteractTrigger.Raise();
    }
    
    public void Reset() {
        StartCoroutine(ChangeShader(3));
        thisButton.onClick.RemoveAllListeners();
        interactTextFront.text = null;
        interactTextBack.text = null;
    }
    
    private void SetNewButtonSprites(Selectable newButton) {
        shader = newButton.image.material;
        defaultImage.material = newButton.image.material;
        thisButton.spriteState = newButton.spriteState;
    }
    
    private IEnumerator ChangeShader(int value) {
        float start = 0;
        float end = 1;
        while (start < end) {
            float changeValue = Mathf.Lerp(shader.GetFloat("ShaderController"), value, Time.deltaTime * 1.5f);
            shader.SetFloat("ShaderController", changeValue);
            start += Time.deltaTime;
            yield return null;
        }
    }

}

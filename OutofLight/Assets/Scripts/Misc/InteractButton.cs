using System;
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
   

    private void Awake() {
        defaultImage = GetComponent<Image>();
        defaultImage.enabled = false;
        defaultImage.sprite = null;
        thisButton = GetComponent<Button>();
    }

    public void SetNewInteract() {
        defaultImage.enabled = true;
        try {
            var interactImage = interact.thisObject.CustomSprite();
            SetNewButtonSprites(interactImage != null ? interactImage : defaultButton);
            print(thisButton);
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
        defaultImage.enabled = false;
        InteractTrigger.Raise();
    }
    
    public void Reset() {
        thisButton.onClick.RemoveAllListeners();
        defaultImage.enabled = false;
        defaultImage.sprite = defaultSprite;
        interactTextFront.text = null;
        interactTextBack.text = null;
    }

    private void SetNewButtonSprites(Selectable newButton) {
        defaultImage.sprite = newButton.image.sprite;
        thisButton.spriteState = newButton.spriteState;
    }
    



}

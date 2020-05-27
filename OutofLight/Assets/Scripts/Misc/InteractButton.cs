using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour {
    
    
    public InteractParameter interact;
    public GameEvent InteractTrigger;
    public Text interactTextFront, interactTextBack;
    public Sprite defaultSprite;
    
    private Button thisButton;
    private Image defaultImage;
   

    private void Awake() {
        defaultImage = GetComponent<Image>();
        defaultImage.enabled = false;
        thisButton = GetComponent<Button>();
    }

    public void SetNewInteract() {
        defaultImage.enabled = true;
        var interactImage = interact.thisObject.CustomSprite();
        if (interactImage != null)
            defaultImage.sprite = interact.thisObject.CustomSprite();
        interactTextFront.text = interact.thisObject.GetPrompt();
        interactTextBack.text = interact.thisObject.GetPrompt();
        thisButton.onClick.AddListener(Interact);
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



}

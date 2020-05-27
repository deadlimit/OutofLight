using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour {
    
    
    public InteractParameter interact;
    public GameEvent InteractTrigger;
    public Text interactTextFront, interactTextBack;
    
    private Button thisButton;
    private Image thisImage;
    
    
    private void Awake() {
        thisImage = GetComponent<Image>();
        thisImage.enabled = false;
        thisButton = GetComponent<Button>();
        
    }

    public void SetNewInteract() {
        thisImage.enabled = true;
        interactTextFront.text = interact.thisObject.GetPrompt();
        interactTextBack.text = interact.thisObject.GetPrompt();
        thisButton.onClick.AddListener(Interact);
    }

    private void Interact() {
        interact.thisObject.Use();
        thisImage.enabled = false;
        InteractTrigger.Raise();
    }
    
    public void Reset() {
        thisButton.onClick.RemoveAllListeners();
        thisImage.enabled = false;
        interactTextFront.text = null;
        interactTextBack.text = null;
    }



}

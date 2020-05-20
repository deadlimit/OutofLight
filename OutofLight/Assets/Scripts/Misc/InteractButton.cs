using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour {
    
    private Button thisButton;
    private Image thisImage;
    private Text interactPrompt;
    public InteractParameter interact;
    
    private void Awake() {
        thisImage = GetComponent<Image>();
        thisImage.enabled = false;
        thisButton = GetComponent<Button>();
        interactPrompt = GetComponentInChildren<Text>();
    }
    
    public void SetNewInteract() {
        thisImage.enabled = true;
        interactPrompt.text = interact.thisObject.GetPrompt();
        thisButton.onClick.AddListener(Interact);
    }

    private void Interact() {
        interact.thisObject.Use();
        thisImage.enabled = false;
    }
    
    public void Reset() {
        thisButton.onClick.RemoveAllListeners();
        thisImage.enabled = false;
    }



}

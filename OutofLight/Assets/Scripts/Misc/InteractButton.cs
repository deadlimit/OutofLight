using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour {
    
    private Button thisButton;
    private Image thisImage;

    public InteractParameter interact;
    
    private void Awake() {
        thisImage = GetComponent<Image>();
        thisImage.enabled = false;
        thisButton = GetComponent<Button>();
    }
    
    public void SetNewInteract() {
        thisImage.enabled = true;
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

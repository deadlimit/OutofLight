using UnityEngine;
using UnityEngine.UI;

public class ItemBehavior : MonoBehaviour, IInteractable {

    public Item item;
    public Button interactImage;
    public string prompt;
    public string GetPrompt() {
        return prompt;
    }

    public Button CustomSprite() {
        return interactImage;
    }


    public void Use() {
        Debug.Log("Name: " + item.name);
        Debug.Log("Description: " + item.description);
        Destroy(this);
    }
    
}

using UnityEngine;
using UnityEngine.UI;

public class ItemBehavior : MonoBehaviour, IInteractable {

    public Item item;
    public Sprite interactImage;
    public string prompt;
    public string GetPrompt() {
        return prompt;
    }

    public Sprite CustomSprite() {
        return interactImage;
    }


    public void Use() {
        Debug.Log("Name: " + item.name);
        Debug.Log("Description: " + item.description);
        Destroy(this);
    }
    
}

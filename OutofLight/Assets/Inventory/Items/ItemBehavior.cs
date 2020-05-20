using UnityEngine;

public class ItemBehavior : MonoBehaviour, IInteractable {

    public Item item;
    public string prompt;
    public string GetPrompt() {
        return prompt;
    }

    public void Use() {
        Debug.Log("Name: " + item.name);
        Debug.Log("Description: " + item.description);
        Destroy(this);
    }
    
}

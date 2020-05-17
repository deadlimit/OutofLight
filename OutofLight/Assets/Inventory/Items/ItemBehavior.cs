using UnityEngine;

public class ItemBehavior : MonoBehaviour, IInteractable {

    public Item item;

    public void Use() {
        Debug.Log("Name: " + item.name);
        Debug.Log("Description: " + item.description);
        Destroy(this);
    }
    
}

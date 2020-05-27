using UnityEngine;
using UnityEngine.UI;

public interface IInteractable {
    void Use();
    string GetPrompt();

    Sprite CustomSprite();
}

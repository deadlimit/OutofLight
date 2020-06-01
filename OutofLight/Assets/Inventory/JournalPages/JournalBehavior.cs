using UnityEngine;
using UnityEngine.UI;

public class JournalBehavior : MonoBehaviour, IInteractable {

    public GameEvent PageFound;
    public JournalPage page;
    public Journal journal;
    public Button interactImage;
    
    
    private void Awake() {
        if (journal.Contains(page) || page.dontRespawn)
            Destroy(gameObject);
    }
    
    public void Use() {
        journal.Add(page);
        PageFound.Raise();
        Destroy(gameObject);
    }

    public JournalPage GetJournalPage() {
        return page;
    }

    public string GetPrompt() {
        return "Pick up journal page";
    }

    public Button CustomSprite() {
        return interactImage;
    }
}

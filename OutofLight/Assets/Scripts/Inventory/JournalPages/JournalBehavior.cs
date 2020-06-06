using UnityEngine;
using UnityEngine.UI;

public class JournalBehavior : MonoBehaviour, IInteractable {

    public GameEvent PageFound;
    public JournalPage page;
    public Journal journal;
    private AudioSource audio;

    public string requirementToSet;
    
    private void Awake() {
        if (journal.Contains(page) || page.dontRespawn)
            Destroy(gameObject);
        
        audio = GetComponent<AudioSource>();
    }
    
    public void Use() {
        if(requirementToSet.Length > 0)
            RequirementManager.Instance.FulfillRequirement(requirementToSet, true);
        audio.Play();
        journal.Add(page);
        PageFound.Raise();
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject, 3);
    }

    public JournalPage GetJournalPage() {
        return page;
    }

    public string GetPrompt() {
        return "Pick up journal page";
    }

    public Button CustomSprite() {
        return null;
    }
}

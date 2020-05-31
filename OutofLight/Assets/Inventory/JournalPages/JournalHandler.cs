using UnityEngine;
using UnityEngine.UI;

public class JournalHandler : MonoBehaviour {
	
    public Journal journal;
    public Text day;
    public Text header;
    public Text entry;

    public JournalPage page;

    public void Awake() {
	    transform.localScale = Vector3.zero;
	    LeanTween.scale(gameObject, new Vector3(1, 1, 1), .5f);
	    page = journal.latest;
        if (page == null) return; 
        day.text = page.day;
        header.text = page.header;
        entry.text = page.entry;
    }
    
    public void Close() { 
	    LeanTween.scale(gameObject, Vector3.zero, .1f).setOnComplete(DestroyThis);
    }

    private void DestroyThis() {
	    Destroy(gameObject);
    }
    
}

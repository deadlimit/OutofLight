using UnityEngine;
using UnityEngine.UI;

public class JournalHandler : MonoBehaviour {

	public Animator anim;
    public Journal journal;
    public Text day;
    public Text header;
    public Text entry;
    
    public void Awake() {
	    var page = journal.latest;
        if (page == null) return; 
        day.text = page.day;
        header.text = page.header;
        entry.text = page.entry;
    }
    
    public void Close() { 
	    anim.SetTrigger("Close");
       Destroy(gameObject, 1.01f);
    }
    
}

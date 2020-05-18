using UnityEngine;

public class UIListener : MonoBehaviour {

	public GameObject journalPageDisplay;
	public GameObject screen
	
	public void DisplayPage() {
		var UITransform = GameObject.FindWithTag("UI").transform;
		Instantiate(journalPageDisplay, UITransform.position, Quaternion.identity, UITransform);
	}
	
	public void 
	
}

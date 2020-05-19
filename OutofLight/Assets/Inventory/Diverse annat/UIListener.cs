using UnityEngine;

public class UIListener : MonoBehaviour {

	public GameObject journalPageDisplay;
	[Header("Fade in + room text")]
	public GameObject roomPresenter;

	private void Awake() {
		
		var presenter = Instantiate(roomPresenter, gameObject.transform);
		presenter.transform.SetAsFirstSibling();
	}
	
	public void DisplayPage() {
		var UITransform = GameObject.FindWithTag("UI").transform;
		Instantiate(journalPageDisplay, UITransform.position, Quaternion.identity, UITransform);
	}
	
}

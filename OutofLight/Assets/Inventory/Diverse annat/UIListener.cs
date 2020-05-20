using UnityEngine;

public class UIListener : MonoBehaviour {

	public GameObject journalPageDisplay, respawnMechanic, player;
	[Header("Fade in + room text")]
	public GameObject roomPresenter;

	private void Awake() {
		
		var presenter = Instantiate(roomPresenter, gameObject.transform);
		presenter.transform.SetAsFirstSibling();
		player = GameObject.FindWithTag("Player");
	}
	
	public void DisplayPage() {
		var UITransform = GameObject.FindWithTag("UI").transform;
		Instantiate(journalPageDisplay, UITransform.position, Quaternion.identity, UITransform);
	}

	public void DisplayGameOver()
	{
		var UITransform = GameObject.FindWithTag("UI").transform;
		Instantiate(respawnMechanic, UITransform.position, Quaternion.identity);
		player.gameObject.GetComponent<Movement>().enabled = false;
	}
	
}

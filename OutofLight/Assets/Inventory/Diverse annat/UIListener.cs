using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIListener : MonoBehaviour {

	public GameObject journalPageDisplay, respawnMechanic, player;
	[Header("Fade in + room text")]
	public GameObject roomPresenter;

	public GameObject blackFade;

	private void Awake() {
		RoomPresenter();
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
	
	public void RoomPresenter() {
	
		var presenter = Instantiate(roomPresenter, gameObject.transform);
		presenter.transform.SetAsFirstSibling();

	}

	public void Blink() {
		var b = Instantiate(blackFade, gameObject.transform);
		b.transform.SetAsFirstSibling();
	}
	


	
}

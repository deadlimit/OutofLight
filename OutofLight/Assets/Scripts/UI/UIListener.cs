using UnityEngine;

public class UIListener : MonoBehaviour {

	public GameObject journalPageDisplay, respawnMechanic, player, stairArrows;
	[Header("Fade in + room text")]
	public GameObject roomPresenter;

	public Canvas canvas;
	public GameObject blackFade;

	private void Awake() {
		RoomPresenter();
		player = GameObject.FindWithTag("Player");
	}
	
	public void DisplayPage() {
		var UITransform = GameObject.FindWithTag("UI").transform;
		Instantiate(journalPageDisplay, canvas.transform.position, Quaternion.identity, UITransform);
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

	public void ShowStairArrows() {
		var arrows = Instantiate(stairArrows, gameObject.transform);
		arrows.transform.SetAsLastSibling();
	}

	public void Blink() {
		var b = Instantiate(blackFade, gameObject.transform);
		b.transform.SetAsFirstSibling();
	}

	


	
}

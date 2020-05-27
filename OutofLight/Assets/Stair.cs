using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Stair : MonoBehaviour, IInteractable {

	public GameEvent ClimbStairs;
	public TransitInfo up;
	public Sprite interactImage;
	private Transform player;

	public string prompt;
	
	private void Awake() {
		ChangeLayerMask("Default");
	}
	
	private void OnTriggerEnter(Collider other) {
		if (!other.gameObject.CompareTag("Player")) return;
		ChangeLayerMask("Interactable");
		player = other.gameObject.transform;
	}

	private void OnTriggerExit(Collider other) {
		if (!other.gameObject.CompareTag("Player")) return;
		ChangeLayerMask("Default");
	}
	
	public void Use() {
		StartCoroutine(MoveUp(up.otherSide));
	}

	public string GetPrompt() {
		return prompt;
	}

	public Sprite CustomSprite() {
		return interactImage;
	}



	public IEnumerator MoveUp(Vector3 direction) {
		ClimbStairs.Raise();
		
		yield return new WaitForSeconds(1);
		player.position = direction;	
		player.GetComponent<Movement>().StartedMoving.Raise();
		player.GetComponent<Movement>().ArrivedAtTarget.Raise();
	}

	private void ChangeLayerMask(string arg) {
		gameObject.layer = LayerMask.NameToLayer(arg);
	}

	
}

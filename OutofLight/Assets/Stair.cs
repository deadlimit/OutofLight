using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal.ShaderGUI;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;

public class Stair : MonoBehaviour, IInteractable {


	public TransitInfo up;
	public float speed;
	public float timeToWaitUntilRotationCorrection;
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
		StartCoroutine(MoveUp());
	}

	public string GetPrompt() {
		return prompt;
	}

	private IEnumerator MoveUp(){
		StartCoroutine(player.GetComponent<Movement>().Move(up.otherSide, speed));
		yield return new WaitForSeconds(timeToWaitUntilRotationCorrection);
		player.localRotation = new Quaternion(0, 0, 0, 0);
	}

	private void ChangeLayerMask(string arg) {
		gameObject.layer = LayerMask.NameToLayer(arg);
	}

}

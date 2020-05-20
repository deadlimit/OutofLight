using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor.Experimental.TerrainAPI;
using UnityEditor.Rendering.Universal.ShaderGUI;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;

public class Stair : MonoBehaviour, IInteractable {

	public CinemachineVirtualCamera stairCamera;
	public TransitInfo up;
	public float speed;
	public float timeToWaitUntilRotationCorrection;
	private Transform player;

	public string prompt;
	
	private void Awake() {
		ChangeLayerMask("Default");
		stairCamera.gameObject.SetActive(false);
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
		stairCamera.gameObject.SetActive(true);
		Vector3 look = new Vector3(up.otherSide.x, 0, up.otherSide.z);
		player.GetComponent<Movement>().LookDirection(look);
		StartCoroutine(player.GetComponent<Movement>().Move(up.otherSide, speed, false));
		yield return new WaitForSeconds(timeToWaitUntilRotationCorrection);
		player.localRotation = new Quaternion(0, 0, 0, 0);
		
	}

	private void ChangeLayerMask(string arg) {
		gameObject.layer = LayerMask.NameToLayer(arg);
	}

	public void MoveCamera() {
		
	}

}

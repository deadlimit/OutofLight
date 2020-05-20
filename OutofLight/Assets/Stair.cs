using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Cinemachine;
using UnityEditor.Experimental.TerrainAPI;
using UnityEditor.Rendering.Universal.ShaderGUI;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;
using UnityEngine.UI;

public class Stair : MonoBehaviour, IInteractable {

	public GameEvent ClimbStairs;
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

	private IEnumerator MoveUp() {
		stairCamera.gameObject.SetActive(true);
		ClimbStairs.Raise();
		
		yield return new WaitForSeconds(2);
		player.position = up.otherSide;
		player.GetComponent<Movement>().ArrivedAtTarget.Raise();
	}

	private void ChangeLayerMask(string arg) {
		gameObject.layer = LayerMask.NameToLayer(arg);
	}

	public void MoveCamera() {
		
	}

}

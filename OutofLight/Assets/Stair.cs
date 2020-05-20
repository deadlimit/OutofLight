using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using Cinemachine;
using UnityEditor.Experimental.TerrainAPI;
using UnityEditor.Rendering.Universal.ShaderGUI;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;
using UnityEngine.UI;

public class Stair : MonoBehaviour, IInteractable {

	public GameEvent ClimbStairs;
	public TransitInfo up;
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
	public IEnumerator MoveUp(Vector3 direction) {
		ClimbStairs.Raise();
		
		yield return new WaitForSeconds(1);
		Debug.Log("MOVE!");
		player.position = direction;
		player.GetComponent<Movement>().StartedMoving.Raise();
		player.GetComponent<Movement>().ArrivedAtTarget.Raise();
	}

	private void ChangeLayerMask(string arg) {
		gameObject.layer = LayerMask.NameToLayer(arg);
	}

	
}

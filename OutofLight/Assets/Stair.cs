using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal.ShaderGUI;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;

public class Stair : MonoBehaviour, IInteractable {
	

	private void Awake() {
		ChangeLayerMask("Default");
	}
	
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) { 
			ChangeLayerMask("Interactable");
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			ChangeLayerMask("Default");
		}
	}
	
	public void Use() {
		Debug.Log("Stair");
	}

	private void ChangeLayerMask(string arg) {
		gameObject.layer = LayerMask.NameToLayer(arg);
	}

}

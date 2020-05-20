using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class HugeWindowInspection : MonoBehaviour, IInteractable {

	public CinemachineVirtualCamera inspectCamera;
	public GameObject dave;
	
	private void Awake() {
		inspectCamera.gameObject.SetActive(false);
	}
	
	public void Use() {
		inspectCamera.gameObject.SetActive(true);
		dave.transform.LookAt(gameObject.transform);
	}


	public string GetPrompt() {
		return "Inspect";
	}
}

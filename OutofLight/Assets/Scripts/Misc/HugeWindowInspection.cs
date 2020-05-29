using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class HugeWindowInspection : MonoBehaviour, IInteractable {
	
	public GameObject dave;
	public GameEvent UpdateTileCheck;
	public Button interactImage;
	public string prompt;
	private bool isLooking;

	public AudioSource audio;
	
	private void Awake() {
		isLooking = false;
	}
	
	public void Use() {
		StartCoroutine(InspectSequence());
		audio.Play();
	}


	private IEnumerator InspectSequence() {
		
		dave.GetComponent<Movement>().enabled = false;
		CameraController.instance.ActivateWindowCamera();
		yield return new WaitForSeconds(3);
		dave.GetComponent<Movement>().enabled = true;
		CameraController.instance.ActivateStaticCamera();
		UpdateTileCheck.Raise();
	}
	
	public string GetPrompt() {
		return prompt;
	}

	public Button CustomSprite() {
		return interactImage;
	}
	
}

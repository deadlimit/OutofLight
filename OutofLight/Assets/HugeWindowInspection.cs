using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class HugeWindowInspection : MonoBehaviour, IInteractable {
	
	public GameObject dave;
	public GameEvent Inspecting;
	public GameEvent StopInspectiong;
	public Sprite interactImage;
	public string prompt;
	private bool isLooking;

	private void Awake() {
		isLooking = false;
	}
	
	public void Use() {
		if (!isLooking) {
			Inspecting.Raise();
			CameraController.instance.ActivateWindowCamera();
			isLooking = true;
			dave.GetComponent<Movement>().ArrivedAtTarget.Raise();
			
		}
		else {
			StopInspectiong.Raise();
			isLooking = false;
			CameraController.instance.ActivateStaticCamera();
		}
		
	}
	
	public string GetPrompt() {
		return prompt;
	}

	public Sprite CustomSprite() {
		return interactImage;
	}
	
}

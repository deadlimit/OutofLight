using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class HugeWindowInspection : MonoBehaviour, IInteractable {
	
	public GameObject dave;
	
	private bool isLooking;
	
	public void Use() {
		if (!isLooking) {
			CameraController.instance.ActivateWindowCamera();
			dave.transform.LookAt(new Vector3(transform.position.x, transform.position.y, 0));
			isLooking = true;
			dave.GetComponent<Movement>().ArrivedAtTarget.Raise();
			
		}
		else {
			isLooking = false;
			CameraController.instance.ActivateStaticCamera();
		}
		
	}


	public string GetPrompt() {
		return isLooking ? "Inspect" : "Stop inspect";
	}
}

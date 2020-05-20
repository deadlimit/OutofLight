using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public CinemachineVirtualCamera mainViewCamera;
	public CinemachineVirtualCamera staticStairCamera;
	public CinemachineVirtualCamera leftBalconyCamera;
	public CinemachineVirtualCamera rightBalconyCamera;

	
	public static CameraController instance;
	private void Awake() {
		if (instance == null)
			instance = this;
		else if(instance != null)
			Destroy(gameObject);
	}

	public void ActivateMainCamera() {
		mainViewCamera.gameObject.SetActive(true);
		staticStairCamera.gameObject.SetActive(false);
		leftBalconyCamera.gameObject.SetActive(false);
		rightBalconyCamera.gameObject.SetActive(false);
	}

	public void ActivateLeftBalconyCamera() {
		mainViewCamera.gameObject.SetActive(false);
		staticStairCamera.gameObject.SetActive(false);
		leftBalconyCamera.gameObject.SetActive(true);
		rightBalconyCamera.gameObject.SetActive(false);
	}

	public void ActiveRightBalconyCamera() {
		mainViewCamera.gameObject.SetActive(false);
		staticStairCamera.gameObject.SetActive(false);
		leftBalconyCamera.gameObject.SetActive(false);
		rightBalconyCamera.gameObject.SetActive(true);
	}
	
	public void ActivateStaticCamera() {
		mainViewCamera.gameObject.SetActive(false);
		staticStairCamera.gameObject.SetActive(true);
		leftBalconyCamera.gameObject.SetActive(false);
		rightBalconyCamera.gameObject.SetActive(false);
	}
	
}

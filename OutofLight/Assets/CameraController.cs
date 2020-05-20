﻿using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField] private CinemachineVirtualCamera mainViewCamera;
	[SerializeField] private CinemachineVirtualCamera staticStairCamera;
	[SerializeField] private CinemachineVirtualCamera leftBalconyCamera;
	[SerializeField] private CinemachineVirtualCamera rightBalconyCamera;
	[SerializeField] private CinemachineVirtualCamera windowInspectCamera;

	
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
		windowInspectCamera.gameObject.SetActive(false);
	}

	public void ActivateLeftBalconyCamera() {
		mainViewCamera.gameObject.SetActive(false);
		staticStairCamera.gameObject.SetActive(false);
		leftBalconyCamera.gameObject.SetActive(true);
		rightBalconyCamera.gameObject.SetActive(false);
		windowInspectCamera.gameObject.SetActive(false);
	}

	public void ActiveRightBalconyCamera() {
		mainViewCamera.gameObject.SetActive(false);
		staticStairCamera.gameObject.SetActive(false);
		leftBalconyCamera.gameObject.SetActive(false);
		rightBalconyCamera.gameObject.SetActive(true);
		windowInspectCamera.gameObject.SetActive(false);
	}
	
	public void ActivateStaticCamera() {
		mainViewCamera.gameObject.SetActive(false);
		staticStairCamera.gameObject.SetActive(true);
		leftBalconyCamera.gameObject.SetActive(false);
		rightBalconyCamera.gameObject.SetActive(false);
		windowInspectCamera.gameObject.SetActive(false);
	}

	public void ActivateWindowCamera() {
		mainViewCamera.gameObject.SetActive(false);
		staticStairCamera.gameObject.SetActive(false);
		leftBalconyCamera.gameObject.SetActive(false);
		rightBalconyCamera.gameObject.SetActive(false);
		windowInspectCamera.gameObject.SetActive(true);
	}
	
}

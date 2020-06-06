using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour {
	

	public List<CinemachineVirtualCamera> cameraList = new List<CinemachineVirtualCamera>();
	public CinemachineVirtualCamera activeCamera;
	public static CameraController instance;
	
	private void Awake() {
		foreach (var camera in cameraList) {
			camera.Priority = 1;
		}
		activeCamera.Priority = 300;
			
		
		if (instance == null)
			instance = this;
		else if(instance != null)
			Destroy(gameObject);
	}

	public void ActivateCamera(CinemachineVirtualCamera camera) {
		activeCamera.Priority = 1;
		camera.Priority = 300;
		activeCamera = camera;
	}
}

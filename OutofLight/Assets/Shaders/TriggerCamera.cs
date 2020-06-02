using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Cinemachine;
using UnityEngine;

public class TriggerCamera : MonoBehaviour {

	public CinemachineVirtualCamera camera;

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player"))
			camera.enabled = true;
	}

}

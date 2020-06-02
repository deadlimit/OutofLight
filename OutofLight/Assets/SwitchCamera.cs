using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {

	public CinemachineVirtualCamera main, room;

	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			if (main.enabled) {
				main.enabled = false;
				room.enabled = true;
			}
			else {
				main.enabled = true;
				room.enabled = false;
			}
		}
	}
}

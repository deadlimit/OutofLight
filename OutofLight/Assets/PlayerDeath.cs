using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

	public GameObject lantern;

	public void DropLantern() {
		lantern.transform.parent = null;
		lantern.AddComponent<BoxCollider>();
		Vector3 direction = Direction();
		Rigidbody rb = lantern.AddComponent<Rigidbody>();
		rb.AddForce(direction * 55, ForceMode.Force);
	}


	private Vector3 Direction() {
		var y = (int)transform.rotation.y;

		switch (y) {
			case 0:
				return Vector3.forward;
			case 180:
				return Vector3.back;
			case 90:
				return Vector3.left;
			default:
				return Vector3.right;
		}
	}
}

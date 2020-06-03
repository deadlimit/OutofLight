using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

	public GameObject lantern;
	public float force;
	public GameObject respawnMenu;



	public void DropLantern() {
		lantern.transform.parent = null;
		lantern.AddComponent<BoxCollider>();
		Rigidbody rb = lantern.AddComponent<Rigidbody>();
		
		rb.AddForce(transform.forward * force, ForceMode.Acceleration);
		rb.AddTorque(transform.forward * (force * 4), ForceMode.Impulse);
		Invoke("ShowRespawnMenu", 3f);
	}

	private void ShowRespawnMenu()
	{
		var UITransform = GameObject.FindWithTag("UI").transform;
		Instantiate(respawnMenu, UITransform.position, Quaternion.identity);
	}
	
}


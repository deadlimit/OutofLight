using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

	public Transform player;
	private Transform thisTransform;
	private void Awake() {
		thisTransform = GetComponent<Transform>(); 
		player = GameObject.FindWithTag("Player").transform;
	}

	private void Update() {
		var wef = GetPlayerDirection();
		thisTransform.rotation = Quaternion.Slerp(thisTransform.rotation, wef, Time.deltaTime);
	}

	private Quaternion GetPlayerDirection() {
		var lookDirection = player.position - thisTransform.position;
		lookDirection.y = 0;
		return Quaternion.LookRotation(lookDirection);
	}

}

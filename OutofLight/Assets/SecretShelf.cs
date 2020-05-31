using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SecretShelf : MonoBehaviour {

	public Vector3 target;

	public void Move() {
		StartCoroutine(MoveToNewSpot());
	}
	
	private IEnumerator MoveToNewSpot() {
		while (Vector3.Distance(transform.position, target) > .01) {
			transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime);
			transform.rotation = Quaternion.Euler(new Vector3(-90, 180, -90));
			yield return null;
		}
		
	}
	
}

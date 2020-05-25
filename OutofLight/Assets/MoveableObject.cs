using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour {

	public Vector3 destination;
	
	public void Move() {
		StartCoroutine(IMove());
	}

	private IEnumerator IMove() {
		var target = transform.position + destination;
		while (Vector3.Distance(transform.position, target) > .01f) {
			transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime / 2);
			yield return null;
		}
	}
}

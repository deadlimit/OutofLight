using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour {

	public GameEvent ShowStairArrows;

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			ShowStairArrows.Raise();
		}
	}

}

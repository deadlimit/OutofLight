using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousBall : MonoBehaviour {

	public List<Tile> moveList = new List<Tile>();
	public float moveSpeed;
	public GameEvent HitByTrap;
	private int index;

	private bool canMove;
	
	private void Awake() {
		index = 0;
		canMove = true;
		transform.position = Next();

	}

	public void Update() {
		if(canMove)
			StartCoroutine(Move());
	}

	private IEnumerator Move() {
		canMove = false;
		var target = Next();
		while (transform.position != target) {
			transform.position = Vector3.MoveTowards(transform.position, target, 1f * Time.deltaTime * moveSpeed);
			yield return null;
		}

		canMove = true;
	} 

	private Vector3 Next() {

		if (index > moveList.Count -1 )
			index = 0;

		return moveList[index++].transform.position + Vector3.up;;
	}


	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			HitByTrap.Raise();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GhostMovement : MonoBehaviour {
	
	public IntVariable steps;
	public int lowerValue;
	public Transform player;

	public GhostPathfinding pathfinding;
	public GameEvent GhostUpdatePath;

	private Transform thisTransform;

	private void Awake() {
		thisTransform = GetComponent<Transform>(); 
		player = GameObject.FindWithTag("Player").transform;
	}

	private void Update() {
		var direction = GetPlayerDirection();
		thisTransform.rotation = Quaternion.Slerp(thisTransform.rotation, direction, Time.deltaTime * 2 );

	}
	
	
	public void Move() {
		StartCoroutine(MoveGhost());
	}
	
	private IEnumerator MoveGhost() {
		var nextTile = pathfinding.NextTile();
		nextTile.y = .5f;
		while (Vector3.Distance(thisTransform.position, nextTile) > .01f) {
			thisTransform.position =
				Vector3.MoveTowards(thisTransform.position, nextTile, Time.deltaTime * 10);
			yield return null;
		}
		GhostUpdatePath.Raise();
	}
	
	
	private Quaternion GetPlayerDirection() {
		var lookDirection = player.position - thisTransform.position;
		lookDirection.y = .25f;
		return Quaternion.LookRotation(lookDirection);
	}
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			steps.ChangeValue(lowerValue);
		} 
	}
	
	
}

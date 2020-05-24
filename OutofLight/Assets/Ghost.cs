using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ghost : MonoBehaviour {

	
	public IntVariable steps;
	public int lowerValue;
	public Transform player;
	public Transform rayCheckPosition;
	
	private Transform thisTransform;
	public List<Tile> tiles = new List<Tile>();
	public List<Tile> path = new List<Tile>();
	
	private void Awake() {
		thisTransform = GetComponent<Transform>(); 
		player = GameObject.FindWithTag("Player").transform;
		StartCoroutine(MapOutPath());
	}

	private void Update() {
		var direction = GetPlayerDirection();
		thisTransform.rotation = Quaternion.Slerp(thisTransform.rotation, direction, Time.deltaTime * 2 );

	}
	
	private void CastRays() {
		Ray(rayCheckPosition, Vector3.back);
		Ray(rayCheckPosition, Vector3.forward);
		Ray(rayCheckPosition, Vector3.left);
		Ray(rayCheckPosition, Vector3.right);

		tiles = tiles.OrderBy(tile => Vector3.Distance(tile.transform.position, player.position)).ToList();
		
	}
	
	
	private IEnumerator MapOutPath() {
		ClearColors();
		path.Clear();
		rayCheckPosition.position = thisTransform.position;
		CastRays();
		while(Vector3.Distance(rayCheckPosition.position, player.position) > 1f && tiles.Count < 20) {
			var newPosition = tiles[0].transform.position;
			newPosition.y = .5f;
			rayCheckPosition.position = newPosition;
			tiles[0].HighlightTile(Color.black);
			path.Add(tiles[0]);
			tiles.Clear();
			CastRays();
			yield return null;
		}
		tiles.Clear();
		rayCheckPosition.position = thisTransform.position;
	}
	
	public void Map() {
		StartCoroutine(MapOutPath());
	}
	
	public void Move() {
		StartCoroutine(MoveGhost());
	}
	
	private IEnumerator MoveGhost() {
		while (Vector3.Distance(thisTransform.position, path[0].transform.position) > .1f) {
			var target = path[0].transform.position;
			target.y = .5f;
			thisTransform.position =
				Vector3.MoveTowards(thisTransform.position, target, Time.deltaTime);
			yield return null;
		}
	}

	public void ClearColors() {
		foreach (Tile tile in path) {
			tile.HighlightTile(Color.white);
		}
	}

	private void Ray(Transform thisOrigin, Vector3 direction) {
        
		var ray = new Ray(thisOrigin.position, direction - new Vector3(0, .5f, 0));
        
		var hitObject = Physics.Raycast(ray, out var hitInfo);
		if (!hitObject || !hitInfo.transform.gameObject.CompareTag("Tile")) return;
		var tile = hitInfo.transform.gameObject.GetComponent<Tile>();
		if(!tiles.Contains(tile))
			tiles.Add(tile);

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

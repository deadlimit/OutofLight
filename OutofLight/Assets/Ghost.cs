using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Animations;

public class Ghost : MonoBehaviour {

	public List<Tile> tiles = new List<Tile>();

	public List<Tile> path = new List<Tile>();
	
	public Transform player;
	public Transform rayCheckPosition;
	private Transform thisTransform;
	private void Awake() {
		thisTransform = GetComponent<Transform>(); 
		player = GameObject.FindWithTag("Player").transform;
		StartCoroutine(MapOutPath());
	}

	private void Update() {
		var wef = GetPlayerDirection();
		thisTransform.rotation = Quaternion.Slerp(thisTransform.rotation, wef, Time.deltaTime);
	}

	public void Map() {
		StartCoroutine(MapOutPath());
	}

	public void CastRays() {
		Ray(rayCheckPosition, Vector3.back);
		Ray(rayCheckPosition, Vector3.forward);
		Ray(rayCheckPosition, Vector3.left);
		Ray(rayCheckPosition, Vector3.right);

		tiles = tiles.OrderBy((t) => (Vector3.Distance(t.transform.position, player.transform.position))).ToList();
		if(!path.Contains(tiles[0]))
			path.Add(tiles[0]);
	}
	

	private IEnumerator MapOutPath() {
		path.Clear();
		CastRays();
		var target = player.position;
		target.y = .5f; 
		while(Vector3.Distance(rayCheckPosition.position, target) > .1f) {
			var newPosition = tiles[0].transform.position;
			newPosition.y = .5f;
			rayCheckPosition.position = newPosition;
			tiles[0].HighlightTile(Color.green);
			CastRays();
			yield return null;
		}
		tiles.Clear();
		rayCheckPosition.position = this.thisTransform.position;

	}

	public void ClearColor() {
		foreach(Tile tile in path)
			tile.HighlightTile(Color.white);
	}

	public void Movee() {
		StartCoroutine(Move());
	}
	
	private IEnumerator Move() {
		while (Vector3.Distance(thisTransform.position, path[0].transform.position) > .1f) {
				var target = path[0].transform.position;
				target.y = .5f;
				thisTransform.position =
					Vector3.MoveTowards(thisTransform.position, target, Time.deltaTime);
				
				yield return null;
		}
	}
	

	private Quaternion GetPlayerDirection() {
		var lookDirection = player.position - thisTransform.position;
		lookDirection.y = .25f;
		return Quaternion.LookRotation(lookDirection);
	}
	
	private void Ray(Transform thisOrigin, Vector3 direction) {
        
		var ray = new Ray(thisOrigin.position, direction - new Vector3(0, .5f, 0));
        
		var hitObject = Physics.Raycast(ray, out var hitInfo);
		if (hitObject && hitInfo.transform.gameObject.CompareTag("Tile")) {
			tiles.Add(hitInfo.transform.gameObject.GetComponent<Tile>());
		}

		Debug.DrawRay(thisOrigin.position, direction - new Vector3(0, .5f, 0), Color.red, 0);
	}
	

}

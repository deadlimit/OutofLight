using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Internal;

public class GhostPathfinding : MonoBehaviour {

	public Transform player;
	public List<Tile> tiles = new List<Tile>();
	public List<Tile> closestPath = new List<Tile>();

	public List<Tile> visited = new List<Tile>();
	
	private void Awake() {
		player = GameObject.FindWithTag("Player").transform;
		Debug.Log(player.transform.position);
		CastRays();
		StartCoroutine(CreatePath());
	}

	public IEnumerator CreatePath() {
		while (Vector3.Distance(transform.position, player.position) > 1f) {
			MoveToNextTile();
			CastRays();
			yield return new WaitForSeconds(2);
		}
	}
	
	public void CastRays() {
		GetNeighbourTiles(Vector3.back);
		GetNeighbourTiles(Vector3.forward);
		GetNeighbourTiles(Vector3.right);
		GetNeighbourTiles(Vector3.left);
		GetCurrentTile();
		
		tiles = tiles.OrderBy(tile => Vector3.Distance(tile.transform.position, player.transform.position)).ToList();
	}
	
	private void GetNeighbourTiles(Vector3 direction) {
		var rayTarget = new Vector3(direction.x, -.5f, direction.z);
		var ray = new Ray(transform.position, rayTarget);
		if (!Physics.Raycast(ray, out var hit, 3)) return;
		var tile = hit.transform.gameObject.GetComponent<Tile>();
		Debug.Log(tile);
		Debug.DrawRay(transform.position, rayTarget, Color.red, 3);
		if (tile != null && !(visited.Contains(tile))) {
			tiles.Add(tile);
		}
	}
	

	private void GetCurrentTile() {
		var ray = new Ray(transform.position, Vector3.down);
		if (!Physics.Raycast(ray, out var hit, 2)) return;
		var tile = hit.transform.gameObject.GetComponent<Tile>();
		if (tile != null && !visited.Contains(tile)) 
			visited.Add(tile);
	}
	
	private void MoveToNextTile() {
		var closestTile = tiles[0];
		closestPath.Add(closestTile);
		Debug.Log(closestTile);
		transform.position = new Vector3(closestTile.transform.position.x, .5f, closestTile.transform.position.z);
		tiles.Clear();
	}
	
}

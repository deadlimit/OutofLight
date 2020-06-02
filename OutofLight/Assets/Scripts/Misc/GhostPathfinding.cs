using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GhostPathfinding : MonoBehaviour {

	public Transform player;
	public List<Tile> closestPath = new List<Tile>();
	
	private List<Tile> tiles = new List<Tile>();
	private List<Tile> visited = new List<Tile>();
	
	public void Awake() {
		player = GameObject.FindWithTag("Player").transform;
		Debug.Log(player.transform.position);
		GeneratePath();
	}

	public void GeneratePath() {
		transform.position = transform.parent.position;
		tiles.Clear();
		closestPath.Clear();
		visited.Clear();
		CastRays();
		StartCoroutine(CreatePath());
	}

	public Vector3 NextTile() {
		return closestPath.Count > 0 ? closestPath[0].transform.position : transform.position;
	}
	
	public IEnumerator CreatePath() {
		while (Vector3.Distance(transform.position, player.position) > 1f) {
			MoveToNextTile();
			CastRays();
			yield return new WaitForSeconds(.5f);
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
		if (!Physics.Raycast(ray, out var hit, 3, LayerMask.GetMask("Tile"))) return;
		var tile = hit.transform.gameObject.GetComponent<Tile>();
		if (tile != null && !(visited.Contains(tile)) && !tile.IsSafezoneTile()) {
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
		if (tiles.Count < 1) return;
		var closestTile = tiles[0];
		closestPath.Add(closestTile);
		Debug.Log(closestTile);
		transform.position = new Vector3(closestTile.transform.position.x, .5f, closestTile.transform.position.z);
		tiles.Clear();
	}
	
}

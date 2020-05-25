using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class Pathfinding : MonoBehaviour {

	public List<Tile> openSet = new List<Tile>();
	public HashSet<Tile> closedSet = new HashSet<Tile>();
	public Dictionary<Tile, float> tileDistance = new Dictionary<Tile, float>();
	public Transform player;

	private void Awake() {
		player = GameObject.FindWithTag("Player").transform;
		Tile[] allTiles = GameObject.FindObjectsOfType<Tile>();
		foreach (var tile in allTiles) {
			openSet.Add(tile);
			tileDistance.Add(tile, Mathf.Infinity);
		}
		var startTile = GetStartTile();
		closedSet.Add(startTile);
		tileDistance[startTile] = 0; 
		
		foreach(var tile in tileDistance.Values)
			print(tile);

		while (closedSet.Count != openSet.Count) {
			
		}
	}

	public void FindPath(Vector3 start, Vector3 end) {
		var startTile = GetStartTile();
		var target = end; 
		
 		List<Tile> openSet = new List<Tile>();
	 	HashSet<Tile> closedSet = new HashSet<Tile>();
	    openSet.Add(startTile);

	    while (openSet.Count > 0) {
		    Tile currentTile = openSet[0];
		    for (int i = 1; i < openSet.Count; i++) {
			    if (openSet[i].fCost() < currentTile.fCost() || openSet[i].fCost() == currentTile.fCost() && openSet[i].hCost < currentTile.fCost()) {
				    currentTile = openSet[i];
			    }
		    }

		    openSet.Remove(currentTile);
		    closedSet.Add(currentTile);
		    if (currentTile.transform.position == target) {
			    return;
		    }
		    
		    
		    
	    }

	}
	
	private Tile GetStartTile() {
		if (!Physics.Raycast(new Ray(transform.position, Vector3.down), out var hit, 2)) return null;
		return hit.transform.gameObject.CompareTag("Tile") ? hit.transform.gameObject.GetComponent<Tile>() : null;
	}
	
}

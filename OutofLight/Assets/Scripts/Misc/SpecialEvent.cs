using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEvent : MonoBehaviour {

    public List<GameEvent> events = new List<GameEvent>();
    public List<GameObject> objectSpawn = new List<GameObject>();
    public List<Vector3> spawnLocations = new List<Vector3>();
    
    
    private Dictionary<GameObject, Vector3> map = new Dictionary<GameObject, Vector3>();

    private void Awake() {
	    for (int i = 0; i < objectSpawn.Count; i++) {
		    map.Add(objectSpawn[i], spawnLocations[i]);
	    }
    }
    
    public void RaiseGameEvents() {
	    foreach(var e in events) {
		    e.Raise();
	    }
    }

    public void SpawnObjects() {
	    foreach (var e in objectSpawn) {
		    Instantiate(e, map[e], Quaternion.identity);
	    }
    }

    private void OnTriggerEnter(Collider other) {
	    if (other.gameObject.CompareTag("Player")) {
		    RaiseGameEvents();
		    SpawnObjects();
	    }
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEvent : MonoBehaviour {

    public List<GameEvent> events = new List<GameEvent>();
    public List<GameObject> objectSpawn = new List<GameObject>();
    public List<Vector3> spawnLocations = new List<Vector3>();
    public string requirementFulFilled;
    
    private Dictionary<GameObject, Vector3> map = new Dictionary<GameObject, Vector3>();

    private void Awake() {
	    if(requirementFulFilled.Length > 0)
	    	if (RequirementManager.Instance.CheckSpecificRequirements(requirementFulFilled))
		    	Destroy(gameObject);
	    
	    for (int i = 0; i < objectSpawn.Count; i++) {
		    map.Add(objectSpawn[i], spawnLocations[i]);
	    }
    }
    
    public void RaiseGameEvents() {
	    try {
		    foreach (var e in events) {
			    e.Raise();
		    }
	    }
	    catch (MissingComponentException e) {
		    print(e.Message);
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
	    
	    if(requirementFulFilled.Length > 0)
	    	RequirementManager.Instance.FulfillRequirement(requirementFulFilled, true);
    }
}

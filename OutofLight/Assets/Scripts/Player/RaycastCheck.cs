﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCheck : MonoBehaviour {

    private List<GameObject> nearbyTiles = new List<GameObject>();

    private Color highlightColor = Color.red;
    private Color defaultColor = Color.white;

    private void Awake() {
        UpdateNearbyTiles(transform);
    }

    private void CastRays(Transform origin) {
        Ray(origin, Vector3.forward);
        Ray(origin, Vector3.back);
        Ray(origin, Vector3.right);
        Ray(origin, Vector3.left);
    }

    private void Ray(Transform origin, Vector3 direction) {
        Ray ray = new Ray(origin.position, direction - new Vector3(0, .5f, 0));
        
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(ray, out hitInfo);

        if (hit && hitInfo.transform.gameObject.CompareTag("Tile")) {
            nearbyTiles.Add(hitInfo.transform.gameObject);
        }
        
    }

    private void ChangeTileColor(Color color) {
        foreach(GameObject tile in nearbyTiles) {
            tile.GetComponent<Tile>().HighlightTile(color);
        }
    }
    
    public void ResetTileColors() {
        ChangeTileColor(defaultColor);
    } 
   
    public void UpdateNearbyTiles(Transform origin) {
        nearbyTiles.Clear();
        CastRays(origin);
        ChangeTileColor(highlightColor);
    }



}

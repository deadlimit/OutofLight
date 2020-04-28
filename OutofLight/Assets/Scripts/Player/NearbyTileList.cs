﻿using System.Collections.Generic;
using UnityEngine;

public class NearbyTileList: MonoBehaviour {

    public ValidMoveDirections validMoveDirections;

    private List<GameObject> nearbyTiles = new List<GameObject>();

    private Color highlightColor = Color.red;
    private Color defaultColor = Color.white;

    private void Start() {
        UpdateNearbyTiles(transform);
    }

    public void ResetTileColors() {
        ChangeTileColor(defaultColor);
    }

    public void UpdateNearbyTiles(Transform origin) {
        validMoveDirections.ClearList();
        nearbyTiles.Clear();
        CastRays(origin);
        ChangeTileColor(highlightColor);
        PopulateValidMoveList();
    }


    #region Private methods
    private void CastRays(Transform origin) {
        Ray(origin, Vector3.forward);
        Ray(origin, Vector3.back);
        Ray(origin, Vector3.right);
        Ray(origin, Vector3.left);
    }

    private void Ray(Transform origin, Vector3 direction) {
        
        Ray ray = new Ray(origin.position, direction - new Vector3(0, .5f, 0));
        
        RaycastHit hitInfo;
        bool isValidTile = Physics.Raycast(ray, out hitInfo);
        Debug.DrawLine(origin.position, direction);
        if (isValidTile && hitInfo.transform.gameObject.CompareTag("Tile")) {
            nearbyTiles.Add(hitInfo.transform.gameObject);
            
        }
        Debug.DrawRay(origin.position, direction - new Vector3(0, .5f, 0), Color.red, 2);
    }

    private void ChangeTileColor(Color color) {
        foreach(GameObject tile in nearbyTiles) {
            tile.GetComponent<Tile>().HighlightTile(color);
        }
    }

    private void PopulateValidMoveList() {
        foreach(GameObject tile in nearbyTiles) {
            validMoveDirections.AddToList(tile.transform.position);
        }
    }
    #endregion


}

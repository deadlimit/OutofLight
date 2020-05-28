using System.Collections.Generic;
using UnityEngine;

public class NearbyTileList: MonoBehaviour {

    public Vector3List validMoveDirections;

    private List<GameObject> nearbyTiles = new List<GameObject>();

    private void Start() {

        UpdateNearbyTiles(transform);
    }
    

    public void UpdateNearbyTiles(Transform origin) {
        validMoveDirections.ClearList();
        nearbyTiles.Clear();
        CastRays(origin);
        PopulateLists();
    }


    #region Private methods
    private void CastRays(Transform origin) {
        Ray(origin, Vector3.forward);
        Ray(origin, Vector3.back);
        Ray(origin, Vector3.right);
        Ray(origin, Vector3.left);
    }

    private void Ray(Transform origin, Vector3 direction) {
        
        var ray = new Ray(origin.position, direction - new Vector3(0, .5f, 0));
        
        var hitObject = Physics.Raycast(ray, out var hitInfo);
        if (hitObject && hitInfo.transform.gameObject.CompareTag("Tile")) {
            nearbyTiles.Add(hitInfo.transform.gameObject);
        }
        
    }
    

    private void PopulateLists() {
        foreach(var tile in nearbyTiles) {
            validMoveDirections.AddToList(tile.transform.position);
        }
    }

    #endregion


}

using System.Collections.Generic;
using UnityEngine;

public class NearbyTileList: MonoBehaviour {

    public Vector3List validMoveDirections;

    private List<GameObject> nearbyTiles = new List<GameObject>();

    public Color highlightColor = Color.red;
    private Color defaultColor = Color.white;

    private void Awake() {
        UpdateNearbyTiles(transform);
    }
    
    private void Start() {
        
    }

    public void ResetTileColors() {
        ChangeTileColor(defaultColor);
    }

    public void UpdateNearbyTiles(Transform origin) {
        validMoveDirections.ClearList();
        nearbyTiles.Clear();
        CastRays(origin);
        ChangeTileColor(highlightColor);
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
        Debug.DrawLine(origin.position, direction);
        if (hitObject && hitInfo.transform.gameObject.CompareTag("Tile")) {
            nearbyTiles.Add(hitInfo.transform.gameObject);
        }

        Debug.DrawRay(origin.position, direction - new Vector3(0, .5f, 0), Color.red, 2);
    }

    private void ChangeTileColor(Color color) {
        foreach(var tile in nearbyTiles) {
            tile.GetComponent<Tile>().HighlightTile(color);
        }
    }

    private void PopulateLists() {
        foreach(var tile in nearbyTiles) {
            validMoveDirections.AddToList(tile.transform.position);
        }
    }

    #endregion


}

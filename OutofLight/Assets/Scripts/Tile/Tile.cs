using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Tile : MonoBehaviour {

    private MeshRenderer mesh;

    public bool isTrapTile;
    
    private void Awake() {

        mesh = GetComponent<MeshRenderer>();
    }

    public void HighlightTile(Color color) {
        mesh.material.color = color;
    }

   
}

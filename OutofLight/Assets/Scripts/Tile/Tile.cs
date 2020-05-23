using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Tile : MonoBehaviour {

    private MeshRenderer mesh;

    [SerializeField] private GameEvent TurnTiles;

    public bool isTrapTile;
    
    
    
    private void Awake() {

        mesh = GetComponent<MeshRenderer>();
    }

    public void HighlightTile(Color color) {
        mesh.material.color = color;
    }

   
}

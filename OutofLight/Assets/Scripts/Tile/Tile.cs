using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Events;

public class Tile : MonoBehaviour {

    private MeshRenderer mesh;

    private float x;
    private float y;

    public int gCost;
    public int hCost;
    
    
    private void Awake() {
        x = transform.position.x;
        y = transform.position.z;
        mesh = GetComponent<MeshRenderer>();
    }

    public void HighlightTile(Color color) {
        mesh.material.color = color;
    }
    
    public override bool Equals(object other) {
        return other is Tile tile && tile == this;
    }

    public int fCost() {
        return gCost + hCost;
    }

    public override int GetHashCode() {
        return (int)(x * y + 2);
    }
}

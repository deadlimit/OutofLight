using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    private MeshRenderer mesh;

    void Awake() {
        mesh = GetComponent<MeshRenderer>();
    }

    public void HighlightTile(Color color ) {
        mesh.material.color = color;
    }

}

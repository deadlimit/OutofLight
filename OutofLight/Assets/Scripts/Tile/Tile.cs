using UnityEngine;

public class Tile : MonoBehaviour {

    private MeshRenderer mesh;

    [Header("Markera som trapTile")]
    public bool trapTile;

    void Awake() {
        mesh = GetComponent<MeshRenderer>();
    }

    public void HighlightTile(Color color ) {
        mesh.material.color = color;
    }
}

using UnityEngine;

public class Tile : MonoBehaviour
{
    private Renderer rnderer;

    void Awake() {
        rnderer = GetComponent<Renderer>();
    }
     
    void OnMouseOver(){
        ChangeTileColor(Color.blue);
    }

    void OnMouseExit() {
        ChangeTileColor(Color.red);
    }

    public void ChangeTileColor(Color color) {
        rnderer.material.color = color;
    }
}

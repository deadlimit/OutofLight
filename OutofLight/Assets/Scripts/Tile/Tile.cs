﻿using System.Collections;
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
        Debug.Log(gameObject);
        mesh.material.color = color;
    }

    public void Turn() {
        if (isTrapTile)
            StartCoroutine(Rotate());
            
        
    }

    private IEnumerator Rotate() {
        var targetAngle = transform.eulerAngles + 180 * Vector3.down;
        while(transform.rotation.z != 180) {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngle, Time.deltaTime * 10);
            yield return null;
        }
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    Terrain t;

    void Awake() {
        t = GetComponent<Terrain>();

        t.AddTreeInstance(new TreeInstance());
    }
}

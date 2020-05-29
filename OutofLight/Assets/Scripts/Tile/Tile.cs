using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Events;

public class Tile : MonoBehaviour {

    public bool safezoneTile;
    
    private float x;
    private float y;
    
    public override bool Equals(object other) {
        return other is Tile tile && tile == this;
    }

    public bool IsSafezoneTile() {
        return safezoneTile;
    }
    
}

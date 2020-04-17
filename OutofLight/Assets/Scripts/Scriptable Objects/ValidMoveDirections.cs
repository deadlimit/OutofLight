using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ValidMoveDirections : ScriptableObject {

    public List<Vector3> validMoveDirections = new List<Vector3>();

    public void AddToList(Vector3 vector) {
        validMoveDirections.Add(vector);
    }

    public void ClearList() {
        validMoveDirections.Clear();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Vector3List : ScriptableObject {

    private List<Vector3> list = new List<Vector3>();

    public void AddToList(Vector3 vector) {
        list.Add(vector);
    }

    public void ClearList() {
        list.Clear();
    }

    public List<Vector3> getDirectionList() {
        return list;
    }


}

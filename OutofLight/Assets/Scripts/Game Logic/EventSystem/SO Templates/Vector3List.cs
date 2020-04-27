using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Vector3List : ScriptableObject {

    private List<Vector3> vectorList = new List<Vector3>();

    public void AddToList(Vector3 vector) {
        vectorList.Add(vector);
    }

    public void ClearList() {
        vectorList.Clear();
    }

    public List<Vector3> getList() {
        return vectorList;
    }


}

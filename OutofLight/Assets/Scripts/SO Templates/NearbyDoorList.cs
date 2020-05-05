using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class NearbyDoorList : ScriptableObject {

    [SerializeField ]private List<Door> list = new List<Door>();

    public void AddToList(Door door) {
        list.Add(door);
    }

    public void ClearList() {
        list.Clear();
    }

    public List<Door> getList() {
        return list;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearbyDoors : MonoBehaviour {

    private List<GameObject> list = new List<GameObject>();

    void Start() {
        UpdateDoorList();
    }

    public void ClearDoorList() {
        SetDoorBool(false);
        list.Clear();
    }

    public void UpdateDoorList() {

        CastRays(transform);
        SetDoorBool(true);
    }

    void SetDoorBool(bool value) {
        if (list.Count <= 0) return;

        foreach(var door in list) {
            door.GetComponent<Door>().IsCloseToDoor(value);
        }
    }

    private void CastRays(Transform origin) {
        Ray(origin, Vector3.forward);
        Ray(origin, Vector3.back);
        Ray(origin, Vector3.right);
        Ray(origin, Vector3.left);
    }

    private void Ray(Transform origin, Vector3 direction) {

        var ray = new Ray(origin.position, direction - new Vector3(0, .5f, 0));

        RaycastHit hitInfo;
        var hitObject = Physics.Raycast(ray, out hitInfo);
        Debug.DrawLine(origin.position, direction);
        if (hitObject && hitInfo.transform.gameObject.CompareTag("Door")) {
            list.Add(hitInfo.transform.gameObject);
        }

        Debug.DrawRay(origin.position, direction - new Vector3(0, .5f, 0), Color.red, 2);
    }

}

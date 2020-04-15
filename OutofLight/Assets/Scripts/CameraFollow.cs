using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    void LateUpdate() {

        Vector3 newPosition = new Vector3(player.position.x, transform.position.y, player.position.z);

        transform.position = Vector3.Lerp(newPosition, transform.localPosition, Time.deltaTime);

    }
}

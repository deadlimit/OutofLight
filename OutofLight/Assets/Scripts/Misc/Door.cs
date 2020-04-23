using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public void MoveUp() {
        StartCoroutine(Move());
    }

    private IEnumerator Move() {

        float startTime = 0;
        float endTime = 2;
        Vector3 targetPosition = transform.position + (Vector3.up * 2.25f);

        while (startTime < endTime) {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime);
            startTime += Time.deltaTime;
            yield return null;
        }
    }

}

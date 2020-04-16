using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    TouchInput touchInput;

    public GameEvent ArrivedAtTarget;
    public GameEvent StartedMoving;

    private bool isMoving;
    private Vector3 swipeDirection;
    void Awake() {
        touchInput = GetComponent<TouchInput>();
        
    }

    void Start() {
        isMoving = false;
    }

    void Update() {

        swipeDirection = touchInput.GetDirection();

        
        if (swipeDirection != Vector3.zero && !isMoving) {
            isMoving = true;
            
            Vector3 destination = swipeDirection + transform.position;
            StartCoroutine(Move(destination));
            
        }
    }


    IEnumerator Move(Vector3 direction) {
        StartedMoving.Raise();

        float startTime = 0;
        float endTime = 1;
        
        while (startTime < endTime) {
            transform.position = Vector3.Lerp(transform.position, direction, 10 * Time.deltaTime);
            startTime += Time.deltaTime;
            
            yield return null;
        }
        ArrivedAtTarget.Raise();
        isMoving = false;
    }


}

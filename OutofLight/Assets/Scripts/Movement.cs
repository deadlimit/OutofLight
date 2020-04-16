using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    TouchInput touchInput;

    private bool isMoving;
    private Vector3 swipeDirection;
    private Rigidbody rb2D;
    void Awake() {
        touchInput = GetComponent<TouchInput>();
        rb2D = GetComponent<Rigidbody>();
    }

    void Start() {
        isMoving = false;
    }

    void Update() {

        swipeDirection = touchInput.GetDirection();

        if(swipeDirection != Vector3.zero && !isMoving) {
            isMoving = true;
            Vector3 destination = swipeDirection + transform.position;
            StartCoroutine(Move(destination));
        }
    }


    IEnumerator Move(Vector3 direction) {

        float startTime = 0;
        float endTime = 1;
        
        while(startTime < endTime) {
            transform.position = Vector3.Lerp(transform.position, direction, .1f);
            startTime += Time.deltaTime;
            yield return null;
        }

       isMoving = false;
    }


}

﻿using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour {

    public GameEvent ArrivedAtTarget;
    public GameEvent StartedMoving;
    public ValidMoveDirections ValidMoveDirections;

    private bool isMoving;
    private Vector3 swipeDirection;
    private TouchInput touchInput;


    void Awake() {
        touchInput = GetComponent<TouchInput>();
    }

    void Start() {
        isMoving = false;
    }

    void Update() {

        swipeDirection = touchInput.GetDirection();

        
        if (swipeDirection != Vector3.zero && !isMoving) {

            if (!CheckIfValidDirection(swipeDirection)) {
                Debug.Log("No valid tile!");
            } else {
                isMoving = true;
                Vector3 destination = swipeDirection + transform.position;
                StartCoroutine(Move(destination));
            }
           
            
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

    private bool CheckIfValidDirection(Vector3 direction) {
        foreach(Vector3 vector in ValidMoveDirections.validMoveDirections) {
            print(vector.x + " " + direction.x);
            print(vector.z + " " + direction.z);
            if (vector.x.Equals(direction.x) || vector.z.Equals(direction.z)) {
                return true;
            }
        }

        return false;
    }


}

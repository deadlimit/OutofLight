﻿using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour {

    public GameEvent ArrivedAtTarget;
    public GameEvent StartedMoving;
    public Vector3List ValidMoveDirections;
    public SpawnPosition SpawnPosition;

    private bool isMoving;
    private Vector3 swipeDirection;
    private Vector3 direction;
    private TouchInput touchInput;
    private Transform thisTransform;

    public BoolVariable UseKeyboard;
    [SerializeField]
    private float timeToMove = 0;


    private void Awake() {
        thisTransform = GetComponent<Transform>();

        touchInput = GetComponent<TouchInput>();
    }

    private void Start() {
        isMoving = false;
        if (Time.time > 1f)
            thisTransform.position = SpawnPosition.spawnPosition;

    }

    private void Update() {

        if (UseKeyboard.IsTrue())
            KeyboardInput();
        else
            SwipeInput();
    }

    private void KeyboardInput() {


        if (Input.GetKeyDown(KeyCode.W)) {
            direction = Vector3.forward;
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            direction = Vector3.back;
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            direction = Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            direction = Vector3.right;
        }

        if (direction == Vector3.zero || isMoving) return;
        if (!CheckIfValidDirection(direction)) {
        } else {
            isMoving = true;
            var destination = direction + transform.position;
            StartCoroutine(Move(destination));
            direction = Vector3.zero;
        }

    }

    private void SwipeInput() {
        swipeDirection = touchInput.GetDirection();

        if (swipeDirection == Vector3.zero || isMoving) return;
        if (!CheckIfValidDirection(swipeDirection)) {
            transform.LookAt(swipeDirection);
        } else {
            isMoving = true;
            var destination = swipeDirection + transform.position;
            StartCoroutine(Move(destination));
        }
    }


    private IEnumerator Move(Vector3 direction) {
        StartedMoving.Raise();

        float startTime = 0;


        while (startTime < timeToMove) {
            transform.position = Vector3.MoveTowards(transform.position, direction, .6f * Time.deltaTime);

            transform.LookAt(direction);

            startTime += Time.deltaTime;
            yield return null;
        }

        ArrivedAtTarget.Raise();
        isMoving = false;
    }

    private bool CheckIfValidDirection(Vector3 direction) {
        foreach (var vector in ValidMoveDirections.GetDirectionList()) {
            var position = thisTransform.position;
            float comparingX = (int)vector.x - (int)position.x;
            float comparingZ = (int)vector.z - (int)position.z;
            var newV = new Vector3(comparingX, 0, comparingZ);
            if (newV == direction)
                return true;
        }

        return false;
    }

}

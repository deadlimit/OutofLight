using System.Collections;
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
    [SerializeField] private float timeToMove;
    [SerializeField] private float speed;


    private void Awake() {
        
        thisTransform = GetComponent<Transform>();

        touchInput = GetComponent<TouchInput>();
        if (Time.time > 1f)
            thisTransform.position = SpawnPosition.spawnPosition;
        isMoving = false;

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
        if (!CheckIfValidDirection(direction))
            LookDirection(direction);
        else {
            isMoving = true;
            var destination = direction + transform.position;
            StartCoroutine(Move(destination, speed, true, timeToMove));
            direction = Vector3.zero;
        }

    }

    private void SwipeInput() {
        swipeDirection = touchInput.GetDirection();
        
        if (swipeDirection == Vector3.zero || isMoving) return;
        if (!CheckIfValidDirection(swipeDirection)) {
            LookDirection(swipeDirection);
        } else {
            isMoving = true;
            var destination = swipeDirection + transform.position;
            StartCoroutine(Move(destination, speed, true, timeToMove));
        }
    }

    public void LookDirection(Vector3 direction) {
        transform.LookAt(direction);
    }


    public  IEnumerator Move(Vector3 direction, float movementSpeed, bool turn, float moveTime) {
        StartedMoving.Raise();

        float startTime = 0;

        while (startTime < moveTime) {
            transform.position = Vector3.MoveTowards(transform.position, direction, .6f * Time.deltaTime * movementSpeed);
            
            if(turn)
                LookDirection(direction);
            
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

    public void UpButton()
    {
        direction = Vector3.forward;
        if (direction == Vector3.zero || isMoving) return;
        if (!CheckIfValidDirection(direction)){}
        else
        {
            isMoving = true;
            var destination = direction + transform.position;
            StartCoroutine(Move(destination, speed, true, timeToMove));
            direction = Vector3.zero;
        }
    }

    public void DownButton()
    {
        direction = Vector3.back;
        if (direction == Vector3.zero || isMoving) return;
        if (!CheckIfValidDirection(direction)) { }
        else
        {
            isMoving = true;
            var destination = direction + transform.position;
            StartCoroutine(Move(destination, speed, true, timeToMove));
            direction = Vector3.zero;
        }
    }

    public void LeftButton()
    {
        direction = Vector3.left;
        if (direction == Vector3.zero || isMoving) return;
        if (!CheckIfValidDirection(direction)) { }
        else
        {
            isMoving = true;
            var destination = direction + transform.position;
            StartCoroutine(Move(destination, speed, true, timeToMove));
            direction = Vector3.zero;
        }
    }

    public void RightButton()
    {
        direction = Vector3.right;
        if (direction == Vector3.zero || isMoving) return;
        if (!CheckIfValidDirection(direction)) { }
        else
        {
            isMoving = true;
            var destination = direction + transform.position;
            StartCoroutine(Move(destination, speed, true, timeToMove));
            direction = Vector3.zero;
        }
    }



}

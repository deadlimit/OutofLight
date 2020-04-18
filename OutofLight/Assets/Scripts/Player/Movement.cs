using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour {

    public GameEvent ArrivedAtTarget;
    public GameEvent StartedMoving;
    public ValidMoveDirections ValidMoveDirections;

    private bool isMoving;
    private Vector3 swipeDirection;
    private Vector3 direction;
    private Rigidbody rb2D;
    private TouchInput touchInput;

    public bool UseKeyboard;
    [SerializeField]
    private float timeToMove = 0; 


    void Awake() {
        touchInput = GetComponent<TouchInput>();
        rb2D = GetComponent<Rigidbody>();
    }

    void Start() {
        isMoving = false;
    }

    void Update() {

        if (UseKeyboard)
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

        if(direction != Vector3.zero && !isMoving) {
            if (!CheckIfValidDirection(direction)) {
                Debug.Log("No valid tile!");
            } else {
                isMoving = true;
                Vector3 destination = direction + transform.position;
                StartCoroutine(Move(destination));
                direction = Vector3.zero;
            }
        }

    }

    private void SwipeInput() {
        swipeDirection = touchInput.GetDirection();

        if (swipeDirection != Vector3.zero && !isMoving) {
            if (!CheckIfValidDirection(swipeDirection)) {
                transform.LookAt(swipeDirection);
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


        while (startTime < timeToMove) {
            transform.position = Vector3.MoveTowards(transform.position, direction, .6f * Time.deltaTime);

            transform.LookAt(direction);

            startTime += Time.deltaTime;
            yield return null;
        }

        ArrivedAtTarget.Raise();
        Debug.Log("Raised");
        isMoving = false;
    }

    private bool CheckIfValidDirection(Vector3 direction) {
        foreach(Vector3 vector in ValidMoveDirections.validMoveDirections) {
            float comparingX = (int)vector.x - (int)transform.position.x;
            float comparingZ = (int)vector.z - (int)transform.position.z;
            Vector3 newV = new Vector3(comparingX, 0, comparingZ);
            if (newV == direction)
                return true;
        }

        return false;
    }


}
